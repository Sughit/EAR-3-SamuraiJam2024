using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    public Transform target;
    [SerializeField] float minDis;

    [SerializeField] GameObject projectile;
    [SerializeField] public float timeBetweenShots;
    [HideInInspector]public float nextShotTime;
    bool canShoot=true;
    Animator anim;
    EnemyHealth health;

    void Awake()
    {
        health = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Time.time > nextShotTime && canShoot && !PlayerHealth.isDead && !health.isDead)
        {
            anim.SetTrigger("atac");
            nextShotTime = Time.time + timeBetweenShots;
        }

        if(Vector2.Distance(transform.position, target.position) < minDis && !PlayerHealth.isDead && !health.isDead)
        {
            canShoot = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else canShoot = true;
    }

    public void Shoot()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
