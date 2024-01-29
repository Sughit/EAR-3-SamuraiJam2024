using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] public float speed;
    public Transform target;
    [SerializeField] float minDis;

    [SerializeField] GameObject projectile;
    [SerializeField] public float timeBetweenShots;
    [HideInInspector]public float nextShotTime;
    bool canShoot=true;
    Animator anim;
    EnemyHealth health;
    float oldPosition;
    Vector2 relative;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector2 localScale = transform.localScale;

        if(Time.time > nextShotTime && canShoot && !PlayerHealth.isDead && !health.isDead)
        {
            nextShotTime = Time.time + timeBetweenShots;
            speed = 0.5f;
            anim.SetTrigger("atac");
        }

        if(Vector2.Distance(transform.position, target.position) < minDis && !PlayerHealth.isDead && !health.isDead)
        {
            nextShotTime = timeBetweenShots;

            canShoot = false;
            anim.SetBool("running", true);

            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

            if(gameObject.transform.position.x > oldPosition)
            {
                localScale.x = 8f;
                relative.x = 8f;
                transform.localScale = localScale;
            }

            if(gameObject.transform.position.x < oldPosition)
            {
                localScale.x = -8f;
                relative.x = -8f;
                transform.localScale = localScale;
            }

            float rev= relative.x;
        }
        else 
        {
            if(target.transform.position.x < transform.position.x)
        {
            localScale.x = -8f;
            transform.localScale = localScale;
        }
        else
        {
            localScale.x = 8f;
            transform.localScale = localScale;
        }
            canShoot = true;
            anim.SetBool("running", false);
        }
    }

    public void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }

    void LateUpdate()
    {
	    oldPosition = transform.position.x;
    }
    public void ResetSpeedRanged()
    {
        speed = 5f;
    }
}
