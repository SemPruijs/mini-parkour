using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 0.125f;
    public Vector3 distanceBetweenObjects;

    void FixedUpdate() {
        Vector3 NormalPosition = target.position + distanceBetweenObjects;
        Vector3 FollowPosition = Vector3.Lerp(transform.position, NormalPosition, smoothspeed * Time.deltaTime);
        transform.position = FollowPosition;
    }

}
