using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector2 moveInput;
    Rigidbody2D rb;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        
        moveInput.Normalize();

        rb.velocity = moveInput * speed;
        Debug.Log(rb.velocity);
    }
}
