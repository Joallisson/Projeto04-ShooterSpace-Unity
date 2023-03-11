using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static GameData instance;
    [HideInInspector] public int highscore;

    private void Awake()
    {
        MakePersistent();
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

    private void MakePersistent()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
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
}
