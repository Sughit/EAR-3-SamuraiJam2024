using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject main, settings, butonSettings, sagetuta, sagetutaBack, butonBackSettings, sunet, butonPlay, butonQuit;
    public Text backText, settingsText;
    public Animator transition;
    void Awake()
    {
        butonSettings.SetActive(false);
        butonPlay.SetActive(false);
        butonQuit.SetActive(false);

        StartCoroutine(Butoane());
    }
    public void PlayGame()
    {
        StartCoroutine(PlayGameCo());
    }

    IEnumerator PlayGameCo()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(.5f);
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
        butonSettings.SetActive(false);
        butonPlay.SetActive(false);
        butonQuit.SetActive(false);

        StartCoroutine(Butoane());
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Sunet()
    {
        Instantiate(sunet);
    }
    IEnumerator Butoane()
    {
        butonQuit.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        butonSettings.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        butonPlay.SetActive(true);
    }
}
