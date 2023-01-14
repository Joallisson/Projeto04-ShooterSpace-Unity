using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.CompareTag("EnemyProjectile"))
        {
            this.gameObject.GetComponent<Player>().health -= target.gameObject.GetComponent<Projectile>().damage;
            Destroy(target.gameObject);

            if(this.gameObject.GetComponent<Player>().health <= 0)
            {
                this.gameObject.GetComponent<Player>().PlayerDeath();
            }
        }
    }
}
