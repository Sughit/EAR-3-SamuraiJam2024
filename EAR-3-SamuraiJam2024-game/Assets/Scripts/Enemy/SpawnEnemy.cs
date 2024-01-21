using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] float timeToSpawn;
    public static int maxNumToSpawn=10;
    public int enemiesSpawned;
    public bool spawnedAll;

    void Spawn()
    {
        Instantiate(enemy[Random.Range(0, enemy.Length)], transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(GameObject.FindWithTag("GameManager").GetComponent<GameManager>().gameStarted)
        {
            if(enemiesSpawned < maxNumToSpawn)
            {
                Invoke("Spawn", Random.Range(timeToSpawn, timeToSpawn * 1.5f));
                enemiesSpawned++;
            }
            else spawnedAll=true;
        }
        else spawnedAll=false;
    }
}
