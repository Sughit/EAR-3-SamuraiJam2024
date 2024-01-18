using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody2D rb;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
 
        if((moveHorizontal == 1 || moveHorizontal == -1) && (moveVertical == 1 || moveVertical == -1))
        {
            rb.velocity = new Vector2 (moveHorizontal*(speed-1), moveVertical*(speed-1));
            Debug.Log(rb.velocity);
        }
        else
        {
            rb.velocity = new Vector2 (moveHorizontal*speed, moveVertical*speed);
            Debug.Log(rb.velocity);
        }
    }
}
