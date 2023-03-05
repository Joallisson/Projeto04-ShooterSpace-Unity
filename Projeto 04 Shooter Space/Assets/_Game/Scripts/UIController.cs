using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Slider sliderPlayerHealth;
    private GameController gameController;
    [SerializeField] private TMP_Text txtScore;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        txtScore.text = "Score: " + gameController.currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        txtScore.text = "Score: " + gameController.currentScore.ToString();
    }
}
