using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public string type;
    public float health, maxHealth = 20f;
    Animator anim;
    public bool isDead;
    BoxCollider2D col;
    public int x;
    public GameObject[] taieturi;
    public SpriteRenderer sprite;
    Transform target;
    public static int kills;
    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        isDead = false;
        anim = GetComponent<Animator>();
        health = maxHealth;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Blood.instance.SpawnBlood();

        StartCoroutine(ColorChange());

        x = UnityEngine.Random.Range(0,8);
        taieturi[x].SetActive(true);

        anim.SetTrigger("hit");
        
        
        if(type == "melee")
        {
            GetComponent<EnemyMovement>().currentTimeToAttack = GetComponent<EnemyMovement>().timeToAttack;
            GetComponent<EnemyMovement>().speed = 0.5f;
        }
        else if(type == "ranged")
        {
            GetComponent<ShootingEnemy>().nextShotTime =  GetComponent<ShootingEnemy>().timeBetweenShots;
            GetComponent<ShootingEnemy>().speed = 0.5f;
        }

        Vector3 direction = (target.transform.position - transform.position) * 3f;
        Vector3 relative = transform.position - direction;
        transform.position = Vector2.Lerp(transform.position, relative, Time.deltaTime);

    }
    public void ResetSpeed()
    {
        if(type == "melee")
        {
            GetComponent<EnemyMovement>().speed = 5f;
        }
        else if(type == "ranged")
        {
            GetComponent<ShootingEnemy>().speed = 3f;
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            isDead = true;
            col.enabled = false;
            anim.SetTrigger("dead");
        }
    }
    public void Die()
    {
        kills++;
        this.transform.parent.gameObject.GetComponent<SpawnEnemy>().spawnedEnemies.Remove(gameObject);
        Destroy(gameObject);  
    }
    IEnumerator ColorChange()
    {
        sprite.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(1f, 1f, 1f, 1f);
    }
}