using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag.Equals("Enemy"))
       {
           GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
           Destroy(collision.gameObject);
           Destroy(explosion, 1f);
           Destroy(gameObject);
       }
       else if(!collision.gameObject.tag.Equals("Untagged"))
       {
           GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
           Destroy(explosion, 1f);
           Destroy(gameObject);
       }
    }
}
