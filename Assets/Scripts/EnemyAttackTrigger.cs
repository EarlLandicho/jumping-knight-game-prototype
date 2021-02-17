using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public float attackSpeed;
    Animator anim;
    GameObject ob;
    Collider2D col2d;
    float boxColSpeed = .1f;
    float boxTimer = 0;

    void Start()
    {
        //col2d is the attack collider
        col2d = gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        //col2d.enabled = false;
    }

    void Update()
    {
        //if (boxTimer > 0)
        //{
        //    boxTimer -= Time.deltaTime;
        //}
        //else
        //{
        //    col2d.enabled = false;
        //}
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            anim.SetTrigger("attack");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            
        }
    }

    //used by animator
    void SetIsAttacking()
    {
        anim.SetBool("isAttacking", true);
    }

    //used by animator
    void ClearIsAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    //used by animator
    void Attack()
    {
        boxTimer = boxColSpeed;
        col2d.enabled = true;
    }
}
