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
    float hurtForce = 60f;
    public Vector3 direction, relative;
    public SpriteRenderer sprite;
    public GameObject[] taieturi;
    public int x;
    void Awake()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    public void TakeDamage(float damage)
    {
        relative = transform.position - direction;
        
        if(canBeHit)
        {
            x = UnityEngine.Random.Range(0,8);
            taieturi[x].SetActive(true);
            transform.position = Vector2.Lerp(transform.position, relative, Time.deltaTime * hurtForce);
            //transform.Translate(Vector2.right * Time.deltaTime * hurtForce);
            //relative = Vector3.zero;
            //direction = Vector3.zero;
            health -= damage;
            anim.SetTrigger("hurt");
            movement.speed = 0.5f;
            playerATK.ResetAttack();
            //sprite.color = new Color(1f, 1f, 1f, 1);
        }
    }

    public void ResetSpeed()
    {
        taieturi[x].SetActive(false);
        //sprite.color = new Color(0f,0f,0f,1);
    }

    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("mort");
        }
    }
}
