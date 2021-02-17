using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animator anim;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            DestroyThis();

            //do something
        }
        
    }

    //called when explosion animation is done
    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
