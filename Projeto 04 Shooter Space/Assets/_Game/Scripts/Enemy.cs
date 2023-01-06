using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private FlashEffect flashEffect;

    // Start is called before the first frame update
    void Start()
    {
        flashEffect = this.gameObject.GetComponent<FlashEffect>();
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
            flashEffect.Flash();

            if(health <= 0)
            {
                Destroy(this.gameObject);
            }

            Destroy(target.gameObject);
        }
    }
}
