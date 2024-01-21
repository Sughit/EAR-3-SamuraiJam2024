using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed = 8f;
    Vector2 moveInput;
    public Rigidbody2D rb;

    [SerializeField] float dashSpeed = 12f;
    [SerializeField] float dashDuration = .3f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash = true;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isDashing) return;
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * speed;
        Vector3 localScale = transform.localScale;
        if(moveInput.x < 0)
            {
                localScale.x = -8f;
                transform.localScale = localScale;
            }
        else if (moveInput.x >0)
            {
                localScale.x = 8f;
                transform.localScale = localScale;
            }


        if(moveInput != Vector2.zero)
            anim.SetBool("mers", true);
        else
            anim.SetBool("mers", false);
        

        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        anim.SetTrigger("dash");
        rb.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
