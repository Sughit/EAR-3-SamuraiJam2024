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

    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > minDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            if(currentTimeToAttack<=0) 
            {
                currentTimeToAttack = timeToAttack;
                Attack();
            }
            else currentTimeToAttack -= Time.deltaTime;
        }
    }

    void Attack()
    {
        target.GetComponent<PlayerHealth>().direction = (transform.position - target.transform.position) * 3f;
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
