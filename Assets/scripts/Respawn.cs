using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    public GameObject player;
    private Vector3 repawnPosision;

    void Start() {
        repawnPosision = new Vector3(-7, -3, 0);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "obstacle")
        {
            print("you died!");
            respawn();
        }

        if (col.gameObject.tag == "checkpoint")
        {
            print("it works!");
            repawnPosision = new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z);
        }
    }

    void respawn() {
        player.transform.position = repawnPosision;
    }
}


