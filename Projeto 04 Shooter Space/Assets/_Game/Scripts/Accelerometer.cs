using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private Rigidbody2D myRB;
    private float dirX, dirY;
    [SerializeField] private float moveSpeedX, moveSpeedY;

    // Start is called before the first frame update
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * (moveSpeedX * Time.deltaTime);
        dirY = Input.acceleration.y * (moveSpeedY * Time.deltaTime);
        transform.position =  new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), Mathf.Clamp(transform.position.y, -7.5f, 7.5f));
    }

    private void FixedUpdate() { //O FixedUpdate serve para fazer cálculo relacionado a física
        myRB.velocity = new Vector2(dirX, dirY);
    }
}
