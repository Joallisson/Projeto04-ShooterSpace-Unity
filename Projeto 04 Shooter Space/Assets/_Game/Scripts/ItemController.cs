using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void ItemShield(Collider2D target)
    {
        if(target.gameObject.CompareTag("Shield"))
        {
            target.transform.parent.gameObject.GetComponent<Player>().InvokePlayerShield();
        }
        else if (target.gameObject.CompareTag("Player"))
        {
            target.gameObject.GetComponent<Player>().InvokePlayerShield();
        }
    }

    public void ItemHealth()
    {
        gameController.PLayerFullHealth();
    }

}
