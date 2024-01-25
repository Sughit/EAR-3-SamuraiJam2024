using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    public GameObject menu;
    public bool menuOpen = false;
    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !menuOpen)
        {
            Time.timeScale = 0f;
            menuOpen = true;
            menu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuOpen)
        {
            Time.timeScale = 1f;
            menuOpen = false;
            menu.SetActive(false);
        }
        
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        menuOpen = false;
        menu.SetActive(false);
    }
}
