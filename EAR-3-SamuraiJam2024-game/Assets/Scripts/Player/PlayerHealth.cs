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
    public GameObject swordHitSelf, projectileHitSelf, endMenu, music, sfxDead, bg, bg2;
    public Blood blood;
    bool f = true;
    void Awake()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        canBeHit = true;
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
            if(f)
            {
                StartCoroutine(Dead());
                f = false;
                }

            music.SetActive(false);

            canBeHit = false;
            playerATK.canAttack = false;
            playerATK.canShuriken = false;

            rb.velocity = Vector2.zero;
        }
    }
    void menu()
    {
        endMenu.SetActive(true);
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
    IEnumerator Dead()
    {
        isDead = true;

        blood.DeleteBlood();

        bg.SetActive(false);
        bg2.SetActive(true);

        Instantiate(sfxDead);

        anim.SetTrigger("death");

        sprite.color = new Color(0.4528302f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(0f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(0.4528302f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(0f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(0.4528302f, 0f, 0f, 1f);
        yield return new WaitForSeconds(0.25f);
        sprite.color = new Color(0f, 0f, 0f, 1f);
        
        Debug.Log("mort");

        Invoke("menu", 3.2f);
    }
}
