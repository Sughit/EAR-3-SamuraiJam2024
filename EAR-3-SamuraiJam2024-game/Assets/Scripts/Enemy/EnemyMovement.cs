using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    public Transform target;
    [SerializeField] float minDis;
    [SerializeField] public float timeToAttack;
    [HideInInspector]public float currentTimeToAttack;
    [SerializeField] float damage;
    float hurtForce = 60f;
    Animator anim;
    EnemyHealth health;
    float oldPosition;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 localScale = transform.localScale;

        if(Vector2.Distance(transform.position, target.position) > minDis && !PlayerHealth.isDead && !health.isDead)
        {
            anim.SetBool("running", true);

            currentTimeToAttack = timeToAttack;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            if(currentTimeToAttack<=0 && !PlayerHealth.isDead && !health.isDead) 
            {
                anim.SetTrigger("atac");
                currentTimeToAttack = timeToAttack;
            }
            else currentTimeToAttack -= Time.deltaTime;

            anim.SetBool("running", false);
        }

        if(gameObject.transform.position.x > oldPosition)
        {
            localScale.x = 8f;
            transform.localScale = localScale;
        }
            if(gameObject.transform.position.x < oldPosition)
        {
            localScale.x = -8f;
            transform.localScale = localScale;
        }
    }

    public void Attack()
    {
        PlayerHealth.meleeAttack = true;
        Vector3 direction = (transform.position - target.transform.position) * 3f;
        Vector3 relative = target.transform.position - direction;
        target.transform.position = Vector2.Lerp(target.transform.position, relative, Time.deltaTime * hurtForce);
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    void LateUpdate()
    {
	    oldPosition = transform.position.x;
    }
}
