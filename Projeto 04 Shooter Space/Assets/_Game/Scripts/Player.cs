using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] Transform spawnProjectilePosition;
    [SerializeField] private float firingRate;
    private float timeToShoot;
    private GameController gameController;
    public int health, maxHealth;

    // Start is called before the first frame update
    void Awake()
    {
        gameController = FindObjectOfType<GameController>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
    }

    private void ShootProjectile()
    {
        timeToShoot += Time.deltaTime;

         if(gameController.shootManual && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && timeToShoot >= firingRate) //Disparo Manual
         {
            GameObject tempProjectile = Instantiate(laserPrefab, spawnProjectilePosition.position, Quaternion.identity) as GameObject;
            timeToShoot = 0f;
            return;
         }
         else if(gameController.shootAutomatic && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && timeToShoot >= firingRate) //Disparo Automático
         {
            GameObject tempProjectile = Instantiate(laserPrefab, spawnProjectilePosition.position, Quaternion.identity) as GameObject;
            timeToShoot = 0f;
            return;
         }
    }

    public void PlayerDeath()
    {
        Explosion explosion = gameController.gameObject.GetComponent<Explosion>();
        explosion.Explode(this.transform);
        this.gameObject.SetActive(false);
    }

}
