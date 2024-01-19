using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
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
        if(other.gameObject.tag != "Enemy") Destroy(gameObject);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
}
