using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private UIController uIController;
    private GameController gameController;

    private void Start()
    {
        uIController = FindObjectOfType<UIController>();
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.CompareTag("EnemyProjectile"))
        {
            this.gameObject.GetComponent<Player>().health -= target.gameObject.GetComponent<Projectile>().damage;
            uIController.sliderPlayerHealth.value = this.gameObject.GetComponent<Player>().health;
            gameController.ChangeColorSliderHealth();
            Destroy(target.gameObject);

            if(this.gameObject.GetComponent<Player>().health <= 0)
            {
                this.gameObject.GetComponent<Player>().PlayerDeath();
            }
        }
    }
}
