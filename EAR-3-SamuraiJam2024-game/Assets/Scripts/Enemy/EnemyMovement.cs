using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public Transform target;
    [SerializeField] float minDis;

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > minDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //attack
        }
    }
}
