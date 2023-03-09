using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    private static SceneController instance;
    
    private void Awake()
    {
       MakePersistent();
    }
    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("teste >>>>>>>>>>>>>>>>>>>>>");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

}
