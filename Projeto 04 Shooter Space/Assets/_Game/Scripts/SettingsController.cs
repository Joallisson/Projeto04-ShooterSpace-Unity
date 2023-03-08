using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    private static SettingsController instance;
    public bool soundOnOff;

    private void Awake()
    {
        MakePersistent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void SoundOnOff()
    {
        if(!soundOnOff)
        {
            soundOnOff = true;
        }
        else if(soundOnOff)
        {
            soundOnOff = false;
        }
    }
}
