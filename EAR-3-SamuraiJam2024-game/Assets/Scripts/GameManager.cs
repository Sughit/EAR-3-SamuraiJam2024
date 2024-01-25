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
    public GameObject dayMusic, nightMusic, sunetUsa;

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
            nightMusic.SetActive(false);
            dayMusic.SetActive(true);
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
        else
        {
            dayMusic.SetActive(false);
            nightMusic.SetActive(true);
        }
    }
    public void Sunet()
    {
        Instantiate(sunetUsa);
    }

    void StartGame()
    {
        transition.SetTrigger("start");
        Sunet();
        StartCoroutine(GameReady());
    }

    IEnumerator GameReady()
    {
        yield return new WaitForSeconds(0.6f);
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
        Blood.instance.DeleteBlood();
        Sunet();
        StartCoroutine(GameUnready());
    }

    IEnumerator GameUnready()
    {
        yield return new WaitForSeconds(.6f);
        transition.SetTrigger("end");
        bg.gameObject.SetActive(false);
        player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
    }
}
