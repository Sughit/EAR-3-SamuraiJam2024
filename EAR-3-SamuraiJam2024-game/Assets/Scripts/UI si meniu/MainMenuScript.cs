using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject main, settings, butonSettings, sagetuta, sagetutaBack, butonBackSettings;
    public void PlayGame()
    {
         SceneManager.LoadScene("Main");
    }
    public void Settings()
    {
        settings.SetActive(true);
        main.SetActive(false);
        butonSettings.transform.localScale = new Vector2(1f, 1f);
        sagetuta.SetActive(false);
    }
    public void BackSettings()
    {
        main.SetActive(true);
        settings.SetActive(false);
        butonBackSettings.transform.localScale = new Vector2(1f, 1f);
        sagetutaBack.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
