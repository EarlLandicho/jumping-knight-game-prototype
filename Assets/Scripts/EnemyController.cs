using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Health
    public float maxHealth = 1;
    float currentHealth;
    bool isDead;

    //Movement
    public float speed = 0;
    Rigidbody2D rb;
    bool facingRight = false;

    //Animation
    Animator anim;

    //Patrol
    public Transform patrolCheck;
    public LayerMask groundLayerFloor;
    public LayerMask groundLayerJumpable;
    float groundCheckRadius = 0.001f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    void FixedUpdate()
    {
        anim.SetFloat("speed", speed);

        if (currentHealth <= 0)
        {
            speed = 0;
        }

        if (rb.velocity.x < 0 && rb.velocity.y == 0 && facingRight && !isDead) //from going right to left
        {

            Flip();
        }
        else if (rb.velocity.x > 0 && rb.velocity.y == 0 && !facingRight && !isDead) //from going left to right
        {
            Flip();
        }

        Patrol();
    }
    void Flip()
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Patrol()
    {
        if (!Physics2D.OverlapCircle(patrolCheck.position, groundCheckRadius, groundLayerFloor) || Physics2D.OverlapCircle(patrolCheck.position, groundCheckRadius, groundLayerJumpable))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (facingRight)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }

    }

    public void DamageThisFor(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("death");
            speed = 0;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Player").GetComponent<Collider2D>());
            //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            //GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void KillThis()
    {
        Destroy(gameObject, 1);
    }
}
