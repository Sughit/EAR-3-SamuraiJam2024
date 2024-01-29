using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInGame : MonoBehaviour
{
    public GameObject menu;
    public bool menuOpen = false;
    public GameObject resumeButton, mainButton, quitButton, sagetuta, sunet;
    public Text resumeText;
    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuOpen)
        {
            StartCoroutine(Butoane());
            menuOpen = true;
            menu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuOpen)
        {
            Time.timeScale = 1f;
            menuOpen = false;

            resumeButton.transform.localScale = new Vector2(1f, 1f);
            sagetuta.SetActive(false);
            resumeText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);

            quitButton.SetActive(false);
            mainButton.SetActive(false);
            resumeButton.SetActive(false);

            menu.SetActive(false);
        }
        
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        EnemyHealth.kills = 0;
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        menuOpen = false;

        resumeButton.transform.localScale = new Vector2(1f, 1f);
        sagetuta.SetActive(false);
        resumeText.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);

        quitButton.SetActive(false);
        mainButton.SetActive(false);
        resumeButton.SetActive(false);

        menu.SetActive(false);
        
    }

    IEnumerator Butoane()
    {
        quitButton.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        mainButton.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        resumeButton.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Sunet()
    {
        Instantiate(sunet);
    }
}
