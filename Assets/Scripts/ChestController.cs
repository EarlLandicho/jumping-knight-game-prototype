using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{



    public GameObject[] potionObjects;
    public GameObject coins;
    [Range(0,10)]
    public int numberOfCoins;

    bool releasedItem = false;
    Animator anim;

    public float offsetY = .5f;
    float releaseRange = 32.0f;
    float releaseForce = 230;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Attack") && !releasedItem)
        {
            GameObject clone;
            for (int i = 0; i < potionObjects.Length; i++)
            {
                
                clone = Instantiate(potionObjects[i], new Vector3(transform.localPosition.x, transform.localPosition.y + offsetY, transform.localPosition.z), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(releaseRange, -releaseRange), releaseForce));
            }

            anim.SetBool("attacked", true);
            


            for(int i = 0; i < numberOfCoins; i++)
            {
                clone = Instantiate(coins, new Vector3(transform.localPosition.x, transform.localPosition.y + offsetY, transform.localPosition.z), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(releaseRange, -releaseRange), releaseForce));
            }

            
            Physics2D.IgnoreCollision(col.gameObject.transform.parent.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            //this.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            releasedItem = true;



        }
    }


}
