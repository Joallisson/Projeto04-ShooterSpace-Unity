using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public bool soundOnOff;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
