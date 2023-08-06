using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private FlashEffect flashEffect;
    private Explosion explosion;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform spawnProjectilePosition;
    [SerializeField] private float startInvokeShoot, minShootValue, maxShootValue;
    private GameController gameController;
    private EnemySpawner enemySpawner;

    [SerializeField] private int pointValue;
    private UIController uIController;

    // Start is called before the first frame update
    void Start()
    {
        flashEffect = this.gameObject.GetComponent<FlashEffect>();
        explosion = FindObjectOfType<Explosion>();
        InvokeProjectile();
        gameController = FindObjectOfType<GameController>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        uIController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeProjectile()
    {
        InvokeRepeating("ShootProjectile", startInvokeShoot, Random.Range(minShootValue, maxShootValue));
    }

    public void ShootProjectile()
    {
        GameObject tempProjectile = Instantiate(projectile, spawnProjectilePosition.position, Quaternion.identity) as GameObject;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.CompareTag("PlayerProjectile") && !gameController.gameover)
        {
            health -= target.gameObject.GetComponent<Projectile>().damage;
            flashEffect.Flash();

            if(health <= 0)
            {
                gameController.CreateItem(this.transform);
                explosion.Explode(this.transform);
                Destroy(this.gameObject);
                gameController.enemyCount--;
                gameController.currentScore += pointValue;
                uIController.UpdateScore();

                if(gameController.enemyCount == 0)
                {
                    gameController.enemyCount = gameController.maxEnemies;
                    enemySpawner.SpawnUntilFull();
                }
            }

            Destroy(target.gameObject);
        }
    }
}
