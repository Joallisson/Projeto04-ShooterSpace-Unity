using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    public void FadeIn()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        switch(sceneName)
        {
            case "Main Menu":
                UIControllerMainMenu uIControllerMainMenu = FindObjectOfType<UIControllerMainMenu>();
                uIControllerMainMenu.imageFade.GetComponent<Animator>().SetTrigger("FadeOut");
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
                break;

            case "Game":
                break;
        }
    }

    public void FadeOut()
    {
        this.gameObject.SetActive(false);
    }
}
