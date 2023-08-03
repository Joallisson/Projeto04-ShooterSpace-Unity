using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Slider sliderPlayerHealth;
    private GameController gameController;
    public TMP_Text txtScore;
    [SerializeField] private GameObject panelPause, panelGame;
    public Image imageFade;
    public Toggle[] shootStyle;

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

    public void ToggleShootStyle()
    {
        GameData gameData = FindObjectOfType<GameData>();

        if(shootStyle[0].isOn)
        {
            //Manual
            gameData.shootStyle = false;
            shootStyle[0].interactable = false;
            shootStyle[1].interactable = true;
        }
        else if(shootStyle[1].isOn)
        {
            //Automático
            gameData.shootStyle = true;
            shootStyle[0].interactable = true;
            shootStyle[1].interactable = false;
        }
    }

    public void ButtonOpenPanelPause()
    {
        panelPause.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ButtonClosePanelPause()
    {
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        GameData gameData = FindObjectOfType<GameData>();
        gameData.SaveSounds(gameData.soundOnOff);
        ToggleShootStyle();
        Time.timeScale = 1f;
    }

    public void ButtonBackMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneController sceneController = FindObjectOfType<SceneController>();
        sceneController.LoadScene(sceneName);
    }

    public void ButtonSound()
    {
        SettingsController settingsController = FindObjectOfType<SettingsController>();
        settingsController.SoundOnOff();
    }
}
