using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public float attackSpeed = 0.9f;
    bool isAttacking = false;
    float attackTimer = 0;
    float boxColSpeed = .1f;
    float boxTimer = 0;

    Animator anim;
    Collider2D col2d;

    void Start()
    {
        col2d = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        col2d.enabled = false;
    }

    void Update()
    {
        // Spawn attack hitbox after mouse is pressed
        if (Input.GetButtonDown("Fire1") && anim.GetBool("swordEquipped"))
        {
            anim.SetTrigger("attack"); //This will trigger Attack() from Animation Event
            anim.SetBool("isAttacking", true);
        }

        //TODO: Clean this up. What the heck is this spaghetti code?
        if (anim.GetBool("isAttacking"))
        {

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;

            }

            if (boxTimer > 0)
            {
                boxTimer -= Time.deltaTime;
            }
            else
            {
                col2d.enabled = false;
            }
        }
    }

    void Attack()
    {
        isAttacking = true;
        attackTimer = attackSpeed;
        boxTimer = boxColSpeed;
        col2d.enabled = true;
    }

    


}
