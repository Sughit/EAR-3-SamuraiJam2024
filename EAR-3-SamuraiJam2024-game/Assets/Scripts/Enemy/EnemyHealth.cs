using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public string type;
    public float health, maxHealth = 20f;
    Animator anim;
    public bool isDead;
    void Awake()
    {
        isDead = false;
        anim = GetComponent<Animator>();
        health = maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Blood.instance.SpawnBlood();
        if(type == "melee")
            GetComponent<EnemyMovement>().currentTimeToAttack = GetComponent<EnemyMovement>().timeToAttack;
        else if(type == "ranged")
            GetComponent<ShootingEnemy>().nextShotTime =  GetComponent<ShootingEnemy>().timeBetweenShots;
    }

    void Update()
    {
        if(health <= 0)
        {
            isDead = true;
            anim.SetTrigger("dead");
        }
    }
    public void Die()
    {
        this.transform.parent.gameObject.GetComponent<SpawnEnemy>().spawnedEnemies.Remove(gameObject);
        Destroy(gameObject);  
    }
}