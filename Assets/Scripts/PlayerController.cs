using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //TODO: Death animation

    //Health
    public float maxHealth = 100;
    float currentHealth;

    //Player movement
    public float speed = 5;
    Rigidbody2D rb;
    bool facingRight = true;

    //Player jump
    public float jumpHeight = 400;
    public LayerMask groundLayer;
    public LayerMask groundLayer2;
    public Transform groundCheck;
    bool isGrounded = false;
    float groundCheckRadius = 0.2f;


    //Animation
    Animator anim;
    bool isSwordEquipped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        //Player jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isGrounded", false);
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpHeight));
        }

        if(Input.GetKeyDown(KeyCode.Tab) && !isSwordEquipped)
        {
            isSwordEquipped = true;
            anim.SetBool("swordEquipped", true);
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && isSwordEquipped)
        {
            isSwordEquipped = false;
            anim.SetBool("swordEquipped", false);
        }
        

    }

    void FixedUpdate()
    {
        if(Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer2))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("verticalSpeed", rb.velocity.y);


        //Player movement
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (move < 0 && facingRight && !anim.GetBool("isAttacking"))
        {
            Flip();
        }
        else if (move > 0 && !facingRight && !anim.GetBool("isAttacking"))
        {
            Flip();
        }

        
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    void Flip()
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void DamageThisFor(float damage)
    {


        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            KillThis();
        }
    }

    private void KillThis()
    {
        Destroy(gameObject);

    }

    void ClearIsAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

}
