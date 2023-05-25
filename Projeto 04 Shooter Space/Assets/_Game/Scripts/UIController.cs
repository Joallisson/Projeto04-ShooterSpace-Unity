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
