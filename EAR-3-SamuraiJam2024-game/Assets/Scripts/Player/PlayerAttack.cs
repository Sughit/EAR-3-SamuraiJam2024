using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] float damage;
    [SerializeField] float attackRate;
    [SerializeField] LayerMask enemyLayer;
    bool canAttack=true;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canAttack)
        {
            Debug.Log("Attack");
            foreach(Collider2D other in Physics2D.OverlapCircleAll(new Vector2(attackPoint.position.x, attackPoint.position.y), attackRange, enemyLayer))
            {
                //attack
                Debug.Log(other.gameObject.name);
            }
            canAttack=false;
            Invoke("ResetAttack", attackRate);
        }
    }

    void ResetAttack()
    {
        canAttack=true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
