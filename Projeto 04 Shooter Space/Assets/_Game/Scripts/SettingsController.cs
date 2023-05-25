using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    private GameData gameData;
    private MainMenu mainMenu;


    private void Awake()
    {
        gameData = FindObjectOfType<GameData>();
        mainMenu = FindObjectOfType<MainMenu>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.music.mute = !gameData.soundOnOff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundOnOff()
    {
        if(!gameData.soundOnOff)
        {
            gameData.soundOnOff = true;
            mainMenu.music.mute = false;
        }
        else if(gameData.soundOnOff)
        {
            gameData.soundOnOff = false;
            mainMenu.music.mute = true;
        }
    }
}
