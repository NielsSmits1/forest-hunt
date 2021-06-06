using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_AI : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject objectPrefab;
    private GameObject player;
    public float waitTime;
    private float currentTime;


    public float arrowForce = 20f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (player)
        {
            Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 ownPos = new Vector2(transform.position.x, transform.position.y);
            transform.rotation = LookAt2D(target - ownPos);

            if (currentTime == 0)
            {
                Shoot();
            }

            if(currentTime < waitTime)
            {
                currentTime += 1 * Time.deltaTime;
            }

            if(currentTime >= waitTime)
            {
                currentTime = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player") && !collision.gameObject.tag.Equals("Missile"))
        {
            Destroy(firePoint);
        }
    }
    void Shoot()
    {
        Instantiate(objectPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }

    Quaternion LookAt2D(Vector2 forward)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
    }
}
