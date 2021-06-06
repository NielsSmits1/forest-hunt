using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float speed = 0.125f;
    public Vector3 offset;
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smootedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = smootedPosition;
        }
    }
}
