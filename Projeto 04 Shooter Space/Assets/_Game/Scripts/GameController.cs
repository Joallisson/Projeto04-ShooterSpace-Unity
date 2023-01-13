using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool shootManual, shootAutomatic;
    public float rotatePartsSpeed;
    [HideInInspector] public int enemyCount;
    public int maxEnemies;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = maxEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
