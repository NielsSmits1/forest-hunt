using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_AI : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    public GameObject hitEffect;
    void Start()
    {
        if(!GameObject.FindGameObjectWithTag("Player")){
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
        else if(!collision.gameObject.tag.Equals("Enemy"))
        {
            GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
    }

}
