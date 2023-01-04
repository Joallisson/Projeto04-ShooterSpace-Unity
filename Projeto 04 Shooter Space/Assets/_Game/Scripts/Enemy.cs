using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.CompareTag("PlayerProjectile"))
        {
            health -= target.gameObject.GetComponent<Projectile>().damage;

            if(health <= 0)
            {
                Destroy(this.gameObject);
            }

            Destroy(target.gameObject);
        }
    }
}
