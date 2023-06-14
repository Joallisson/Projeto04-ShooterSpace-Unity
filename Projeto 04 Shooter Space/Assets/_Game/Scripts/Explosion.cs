
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject[] parts;
    [SerializeField] private float minForce, maxForce;
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Explode(Transform targetPosition)
    {
        GameData gameData = FindObjectOfType<GameData>();
        if (!gameData.soundOnOff)
        {
            parts[0].gameObject.GetComponent<AudioSource>().mute = true;
        }

        for (int i = 0; i < parts.Length; i++)
        {
            GameObject tempParts = Instantiate(parts[i], targetPosition.position, Quaternion.identity) as GameObject;
            tempParts.transform.parent = gameController.allParts;
            Rigidbody2D partsRB = tempParts.gameObject.GetComponent<Rigidbody2D>();
            partsRB.AddForce(new Vector2(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce)), ForceMode2D.Impulse);
            Destroy(tempParts.gameObject, 5f);
        }
        
    }


}
