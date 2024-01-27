using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public Transform target;
    [SerializeField] float minDis;
    [SerializeField] float timeToAttack;
    float currentTimeToAttack;
    [SerializeField] float damage;
    float hurtForce = 60f;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > minDis && !PlayerHealth.isDead)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            if(currentTimeToAttack<=0 && !PlayerHealth.isDead) 
            {
                currentTimeToAttack = timeToAttack;
                Attack();
            }
            else currentTimeToAttack -= Time.deltaTime;
        }
    }

    void Attack()
    {
        PlayerHealth.meleeAttack = true;
        Vector3 direction = (transform.position - target.transform.position) * 3f;
        Vector3 relative = target.transform.position - direction;
        target.transform.position = Vector2.Lerp(target.transform.position, relative, Time.deltaTime * hurtForce);
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
