using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 0;
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyController>().DamageThisFor(attackDamage);
        }
    }

}
