using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [HideInInspector] public int highscore;
    [HideInInspector] public bool soundOnOff;

    private void Awake()
    {
        soundOnOff = GetSounds();
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore(int highscore)
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }

    public int GetScore()
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        return highscore;
    }

    public void SaveSounds(bool soundOnOff)
    {
        if(!soundOnOff)
        {
            PlayerPrefs.SetInt("sounds", 0);
        }
        else if(soundOnOff)
        {
            PlayerPrefs.SetInt("sounds", 1);
        }
    }

    public bool GetSounds()
    {
        if(PlayerPrefs.GetInt("sounds") == 0)
        {
            soundOnOff = false;
        }
        else if (PlayerPrefs.GetInt("sounds") == 1)
        {
            soundOnOff = true;
        }

        return soundOnOff;
    }
}
