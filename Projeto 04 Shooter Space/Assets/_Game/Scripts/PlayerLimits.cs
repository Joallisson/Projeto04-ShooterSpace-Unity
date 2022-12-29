using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private float distanceX, distanceY;

    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMaxWidthHeight();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateX();
        CalculateY();
    }

    private void SetMinAndMaxWidthHeight()
    {
        Vector2 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height)); //pegando a largura e altura da tela

        maxX = screenDimensions.x - distanceX;
        minX = -screenDimensions.x + distanceX;
        maxY = screenDimensions.y - distanceY;
        minY = -screenDimensions.y + distanceY;
    }

    private void CalculateX()
    {
        if(transform.position.x < minX)//ESQUERDA DA TELA
        {
            Vector2 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        else if(transform.position.x > maxX) //DIREITA DA TELA
        {
            Vector2 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    private void CalculateY()
    {
        if(transform.position.y < minY) //BAIXO DA TELA
        {
            Vector2 temp = transform.position;
            temp.y = minY;
            transform.position = temp;
        }
        else if(transform.position.y > maxY) //CIMA DA TELA
        {
            Vector2 temp = transform.position;
            temp.y = maxY;
            transform.position = temp;
        }
    }
}
