using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(target.gameObject);
        }
        else if(target.gameObject.CompareTag("Enemy"))
        {
            //Destroir o inimigo e o jogador
        }
    }


}
