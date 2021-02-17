using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //Do something

            DestroyThis();

        }

    }

    //called when explosion animation is done
    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
