using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelSettings, panelOptions;
    public Image imageFade;
    [SerializeField] private Button buttonStart;

    // Start is called before the first frame update
    void Start()
    {
        buttonStart.interactable = true;
        imageFade.gameObject.SetActive(false);
        //imageFade.gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        ExitGameBackAndroidButton();
    }

    public void ButtonOpenSettings()
    {
        panelSettings.gameObject.SetActive(true);
        panelOptions.gameObject.SetActive(false);
    }

    public void ButtonCloseSettings()
    {
        panelSettings.gameObject.SetActive(false);
        panelOptions.gameObject.SetActive(true);
        GameData gameData = FindObjectOfType<GameData>();
        SettingsController settingsController = FindObjectOfType<SettingsController>();
        gameData.SaveSounds(settingsController.soundOnOff);
    }

    public void ButtonStartGame()
    {
       buttonStart.interactable = false;
       imageFade.gameObject.SetActive(true);
       imageFade.gameObject.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    public void ButtonSound()
    {
        SettingsController settingsController = FindObjectOfType<SettingsController>();
        settingsController.SoundOnOff();
    }

    private void ExitGameBackAndroidButton()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call<bool>("moveTaskToBack", true);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
