using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health, maxHealth = 20f;

    void Awake()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Blood.instance.SpawnBlood();
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        this.transform.parent.gameObject.GetComponent<SpawnEnemy>().spawnedEnemies.Remove(gameObject);
    }
}
