using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed, damage = 5f;
    Transform target;
    Vector2 targetPos;

    void Awake()
    {
        Destroy(gameObject, 1.15f);
        target = GameObject.FindWithTag("Player").transform;
        targetPos = target.transform.position;

        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
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
