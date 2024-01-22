using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth = 20f;
    public Animator anim;
    public PlayerAttack playerATK;
    public Movement movement;
    public static bool canBeHit = true;
    Rigidbody2D rb;
    void Awake()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        if(canBeHit)
        {
            rb.AddForce(transform.right * 20f, ForceMode2D.Impulse);
            health -= damage;
            anim.SetTrigger("hurt");
            movement.speed = 0.5f;
            playerATK.ResetAttack();
            //GetComponent<SpriteRenderer>().color = new Color(0.9433962f, 0.502848f, 0.502848f, 1);
        }
    }

    public void ResetSpeed()
    {
        GetComponent<Movement>().speed = 8f;
        //GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
    }

    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("mort");
        }
    }
}
