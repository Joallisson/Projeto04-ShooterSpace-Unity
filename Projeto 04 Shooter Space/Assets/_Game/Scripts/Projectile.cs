using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    public int damage; //valor do dano

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        GameData gameData = FindObjectOfType<GameData>();
        GameController gameController = FindObjectOfType<GameController>();

        this.transform.parent = gameController.allProjectiles;

        if(!gameData.soundOnOff)
        {
            this.gameObject.GetComponent<AudioSource>().mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(new Vector2(0f, speed * Time.deltaTime));
    }

    public float GetDamage()
    {
        return damage;
    }
}
