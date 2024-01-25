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
    public bool isDashing;
    bool canDash = true;
    Animator anim;
    PlayerAttack playerATK;
    float x;
    public MenuInGame menu;

    void Start()
    {
        playerATK = GetComponent<PlayerAttack>();
        x = playerATK.shurikenSpeed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isDashing) return;
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        if(!PlayerHealth.isDead)
            rb.velocity = moveInput * speed;

        Vector3 localScale = transform.localScale;

        if(moveInput.x < 0 && !PlayerHealth.isDead && !menu.menuOpen)
            {
                localScale.x = -8f;
                playerATK.shurikenSpeed = -x;
                transform.localScale = localScale;
            }
        else if (moveInput.x >0 && !PlayerHealth.isDead && !menu.menuOpen)
            {
                localScale.x = 8f;
                playerATK.shurikenSpeed = x;                
                transform.localScale = localScale;
            }


        if(moveInput != Vector2.zero)
            anim.SetBool("mers", true);
        else
            anim.SetBool("mers", false);
        

        if(Input.GetKeyDown(KeyCode.Space) && canDash && moveInput != Vector2.zero)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        PlayerHealth.canBeHit = false;
        canDash = false;
        isDashing = true;
        anim.SetTrigger("dash");
        rb.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        PlayerHealth.canBeHit = true;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
