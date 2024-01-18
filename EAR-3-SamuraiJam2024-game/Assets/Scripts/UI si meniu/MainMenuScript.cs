using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject main, settings;
    public void PlayGame()
    {
         SceneManager.LoadScene("Main");
    }
    public void Settings()
    {
        settings.SetActive(true);
        main.SetActive(false);
    }
    public void BackSettings()
    {
        main.SetActive(true);
        settings.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
