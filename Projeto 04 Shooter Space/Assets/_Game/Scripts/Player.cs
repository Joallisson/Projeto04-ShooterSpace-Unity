using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] Transform spawnProjectilePosition;
    [SerializeField] private float firingRate;
    private float timeToShoot, playerShieldDuration;
    private GameController gameController;
    public int health, maxHealth;
    private GameObject shield;
    GameData gameData;

    // Start is called before the first frame update
    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        health = maxHealth;
        shield = this.transform.Find("Shield").gameObject;
        playerShieldDuration = gameController.playerShieldDuration;
        gameData = FindObjectOfType<GameData>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
    }

    public void InvokePlayerShield()
    {
        InvokeRepeating("PlayerShield", 0f, 1f);
    }

    private void PlayerShield()
    {
        playerShieldDuration--;

        if(playerShieldDuration > 0)
        {
            shield.gameObject.SetActive(true);
            this.transform.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            shield.gameObject.SetActive(false);
            this.transform.GetComponent<CircleCollider2D>().enabled = true;
            CancelInvoke("PlayerShield");
        }
    }

    private void ShootProjectile()
    {
        timeToShoot += Time.deltaTime;

         if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && !gameData.shootStyle && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && timeToShoot >= firingRate) //Disparo Manual
         {
            GameObject tempProjectile = Instantiate(laserPrefab, spawnProjectilePosition.position, Quaternion.identity) as GameObject;
            timeToShoot = 0f;
            return;
         }
         else if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && gameData.shootStyle && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && timeToShoot >= firingRate) //Disparo Automático
         {
            GameObject tempProjectile = Instantiate(laserPrefab, spawnProjectilePosition.position, Quaternion.identity) as GameObject;
            timeToShoot = 0f;
            return;
         }
    }

    public void PlayerDeath()
    {
        gameController.GameOver();
        Explosion explosion = gameController.gameObject.GetComponent<Explosion>();
        explosion.Explode(this.transform);
        this.gameObject.SetActive(false);
    }

}
