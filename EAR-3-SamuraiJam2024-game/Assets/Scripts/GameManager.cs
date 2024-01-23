using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canStartText;
    [SerializeField] Animator transition;
    public static bool gameStarted;
    [SerializeField] GameObject player;
    [SerializeField] Canvas bg;
    bool canStart;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player") canStart=true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player") canStart=false;
    }

    void Update()
    {
        if(!gameStarted)
        {
            if(canStart)
            {
                canStartText.SetActive(true);
            }
            else canStartText.SetActive(false);
            if(Input.GetKeyDown(KeyCode.E) && canStart)
            {
                canStartText.SetActive(false);
                StartGame();
            }
        }
    }

    void StartGame()
    {
        transition.SetTrigger("start");
        Invoke("GameReady", 0.55f);
    }

    void GameReady()
    {
        canStartText.SetActive(false);
        transition.SetTrigger("end");
        bg.gameObject.SetActive(true);
        player.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        GetComponent<SpawnEnemy>().GenerateWave();
        gameStarted=true;
    }

    public void EndGame()
    {
        gameStarted=false;
        transition.SetTrigger("start");
        Invoke("GameUnready", 0.55f);
    }

    void GameUnready()
    {
        transition.SetTrigger("end");
        bg.gameObject.SetActive(false);
        player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }
}
