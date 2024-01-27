using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed, damage = 5f;
    Transform target;
    Vector3 targetPos;

    void Awake()
    {
        Destroy(gameObject, 3f);
        target = GameObject.FindWithTag("Player").transform;
        targetPos = target.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag != "Enemy") 
        {
            Destroy(gameObject);
            if(other.gameObject.tag == "Player")
                {
                    PlayerHealth.meleeAttack = false;
                    other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                }
        }
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
