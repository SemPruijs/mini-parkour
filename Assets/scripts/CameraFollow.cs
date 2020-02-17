using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 1.3f;
    public Vector3 distanceBetweenObjects;
    public int fasterDistance = 50;

    void FixedUpdate() {
        Vector3 NormalPosition = target.position + distanceBetweenObjects;
        Vector3 FollowPosition = Vector3.Lerp(transform.position, NormalPosition, smoothspeed * Time.deltaTime);
        transform.position = FollowPosition;
        if (NormalPosition.x - FollowPosition.x >= fasterDistance || NormalPosition.y - FollowPosition.y >= fasterDistance || NormalPosition.x - FollowPosition.x <= -fasterDistance || NormalPosition.y - FollowPosition.y <= -fasterDistance)
        {
            smoothspeed = 3f;
        }
        else
        {
            smoothspeed = 1.3f;
        }
    }

}
