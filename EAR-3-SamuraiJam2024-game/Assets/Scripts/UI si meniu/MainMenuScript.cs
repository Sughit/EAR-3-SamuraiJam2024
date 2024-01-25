using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject main, settings, butonSettings, sagetuta, sagetutaBack, butonBackSettings, sunet;
    public Text backText, settingsText;
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
        settingsText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);
    }
    public void BackSettings()
    {
        main.SetActive(true);
        settings.SetActive(false);
        butonBackSettings.transform.localScale = new Vector2(1f, 1f);
        sagetutaBack.SetActive(false);
        backText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Sunet()
    {
        Instantiate(sunet);
    }
}
