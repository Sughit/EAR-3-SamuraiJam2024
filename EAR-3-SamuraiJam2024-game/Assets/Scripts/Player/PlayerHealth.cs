using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth = 20f;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        anim.SetTrigger("hurt");
        GetComponent<Movement>().speed = 0.5f;
        GetComponent<SpriteRenderer>().color = new Color(0.9433962f, 0.502848f, 0.502848f, 1);
    }

    public void ResetSpeed()
    {
        GetComponent<Movement>().speed = 8f;
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }

    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("mort");
        }
    }
}
