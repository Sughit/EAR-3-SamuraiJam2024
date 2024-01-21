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
    bool canAttack=true;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canAttack)
        {
            canAttack=false;
            Debug.Log("Attack");
            anim.SetTrigger("atacL");
            GetComponent<Movement>().speed = 0.5f;
        }

        if(Input.GetMouseButtonDown(1) && canAttack)
        {
            canAttack=false;
            Debug.Log("AttackHeavy");
            anim.SetTrigger("atacH");
            GetComponent<Movement>().speed = 0.5f;
        }
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
