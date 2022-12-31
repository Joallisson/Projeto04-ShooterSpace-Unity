using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        SpawnUntilFull();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnUntilFull()
    {
        Transform availablePosition = NextFreePosition();

        if(availablePosition)
        {
            GameObject tempEnemy = Instantiate(enemyPrefab, availablePosition.position, Quaternion.identity) as GameObject;
            tempEnemy.transform.parent = availablePosition;
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    private Transform NextFreePosition()
    {
        foreach(Transform child in this.transform)
        {
            if(child.childCount == 0) //Se a posição não tiver nenhum inimigo
            {
                return child;
            }
        }

        return null;
    }
}
