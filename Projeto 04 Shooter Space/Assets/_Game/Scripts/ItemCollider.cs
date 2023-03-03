using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    private ItemController itemController;

    // Start is called before the first frame update
    void Start()
    {
        itemController = FindObjectOfType<ItemController>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(this.transform.gameObject.CompareTag("ItemShield"))
        {
            if (target.gameObject.CompareTag("Shield") || target.gameObject.CompareTag("Player"))
            {
                itemController.ItemShield(target);
                Destroy(this.gameObject);
            }
        }
        else if (this.transform.gameObject.CompareTag("ItemHealth"))
        {
            if (target.gameObject.CompareTag("Shield") || target.gameObject.CompareTag("Player"))
            {
                itemController.ItemHealth();
                Destroy(this.gameObject);
            }
        }
    }
}
