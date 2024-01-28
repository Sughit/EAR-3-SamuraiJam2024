using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    public float damage = 5f;
    public GameObject shurikenHit;
    void Awake()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Shuriken") 
        {
            Destroy(gameObject);
            if(other.gameObject.tag == "Enemy")
            {
                if(!other.GetComponent<EnemyHealth>().isDead)
                {
                    Instantiate(shurikenHit);
                    other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
            }
        }
    }
}

