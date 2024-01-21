using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] SpawnEnemy[] spawners;
    int allSpawnersNum;

    void Update()
    {
        // if(allSpawners) 
        // {
        //     if(GetComponent<GameManager>().gameStarted) 
        //     {
        //         Debug.Log("Chemat end game");
        //         allSpawners=false;
        //         GetComponent<GameManager>().EndGame();
        //     }
        // }
    }
}
