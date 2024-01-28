using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth = 20f;
    public Animator anim;
    public PlayerAttack playerATK;
    public Movement movement;
    public static bool canBeHit = true, isDead, meleeAttack;
    Rigidbody2D rb;
    public SpriteRenderer sprite;
    public GameObject[] taieturi;
    public int x;
    public GameObject swordHitSelf, projectileHitSelf, endMenu;
    void Awake()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        if(canBeHit && meleeAttack)
        {
            Instantiate(swordHitSelf);
            x = UnityEngine.Random.Range(0,8);
            taieturi[x].SetActive(true);
            StartCoroutine(ColorChange());
            health -= damage;
            anim.SetTrigger("hurt");
            movement.speed = 0.5f;
            playerATK.ResetAttack();
        }
        else if(canBeHit)
        {
            Instantiate(projectileHitSelf);
            StartCoroutine(ColorChange());
            health -= damage;
            anim.SetTrigger("hurt");
            movement.speed = 0.5f;
            playerATK.ResetAttack();
        }
    }

    public void ResetSpeed()
    {
        taieturi[x].SetActive(false);
    }

    void Update()
    {
        if(health <= 0)
        {
            isDead = true;
            anim.SetTrigger("death");
            Debug.Log("mort");

            endMenu.SetActive(true);

            canBeHit = false;
            playerATK.canAttack = false;
            playerATK.canShuriken = false;
            rb.velocity = Vector2.zero;
        }
    }
    IEnumerator ColorChange()
    {
        sprite.color = new Color(0f, 0f, 0f, 0f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(0f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(0f, 0f, 0f, 0f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(0f, 0f, 0f, 1f);
    }
}
