using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    Vector2 moveInput;
    Rigidbody2D rb;

    [SerializeField] float dashSpeed = 12f;
    [SerializeField] float dashDuration = .3f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash = true;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(isDashing) return;
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * speed;
        
        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
