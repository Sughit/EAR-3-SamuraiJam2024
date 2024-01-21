using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    public Transform target;
    [SerializeField] float minDis;

    [SerializeField] GameObject projectile;
    [SerializeField] float timeBetweenShots;
    float nextShotTime;
    bool canShoot=true;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Time.time > nextShotTime && canShoot)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }

        if(Vector2.Distance(transform.position, target.position) < minDis)
        {
            canShoot = false;
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
        else canShoot = true;
    }
}
