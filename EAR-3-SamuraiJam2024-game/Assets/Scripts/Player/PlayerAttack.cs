using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] float damage;
    [SerializeField] float attackRate, attackHeavyRate;
    [SerializeField] LayerMask enemyLayer;
    bool canAttack=true, canShuriken = true, isAttacking = false;
    Animator anim;
    public GameObject shurikenPrefab;
    public float shurikenSpeed = 20f;
    public float shurikenRate = 1f;
    Movement movement;
    void Awake()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canAttack)
        {
            isAttacking = true;
            canAttack=false;
            Debug.Log("Attack");
            anim.SetTrigger("atacL");
            GetComponent<Movement>().speed = 0.5f;
        }

        if(Input.GetMouseButtonDown(1) && canAttack)
        {
            isAttacking = true;
            canAttack=false;
            Debug.Log("AttackHeavy");
            anim.SetTrigger("atacH");
            GetComponent<Movement>().speed = 0.5f;
        }
        if(Input.GetKeyDown(KeyCode.Q) && canShuriken && !isAttacking && !movement.isDashing)
        {   
            canShuriken = false;
            anim.SetTrigger("shuriken");
            GetComponent<Movement>().speed = 4f;
            ShootShurikens(0);
            ShootShurikens(7);
            ShootShurikens(-7);
            Invoke("ResetShuriken", shurikenRate);
        }
    }

    void ShootShurikens(float y)
    {
        var shuriken = Instantiate(shurikenPrefab);
        shuriken.transform.position = new Vector2(attackPoint.position.x, attackPoint.position.y);
        shuriken.transform.rotation = attackPoint.rotation;
        shuriken.GetComponent<Rigidbody2D>().velocity = new Vector2(shurikenSpeed, y);  
    }
    public void ResetShuriken()
    {
        canShuriken = true;
    }

    public void ResetAttack()
    {
        canAttack=true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    public void ResetSpeed()
    {
        GetComponent<Movement>().speed = 8f;
        isAttacking = false;
    }
    public void ResetSpeedShuriken()
    {
        GetComponent<Movement>().speed = 8f;
    }

    void AttackH()
    {
        foreach(Collider2D other in Physics2D.OverlapCircleAll(new Vector2(attackPoint.position.x, attackPoint.position.y), attackRange, enemyLayer))
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
                Debug.Log(other.gameObject.name);
            }
            Invoke("ResetAttack", attackHeavyRate);
    }

    void AttackL()
    {
        foreach(Collider2D other in Physics2D.OverlapCircleAll(new Vector2(attackPoint.position.x, attackPoint.position.y), attackRange, enemyLayer))
            {
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(5);
                Debug.Log(other.gameObject.name);
            }
            Invoke("ResetAttack", attackRate);
    }
}
