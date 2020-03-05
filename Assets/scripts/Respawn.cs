using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    public GameObject player;
    private Vector3 repawnPosision;

    private AudioSource _audioSource;
    public AudioClip DieClip;
    public AudioClip CheckPointClip;
    

    void Start() {
        repawnPosision = new Vector3(-7, -3, 0);
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionExit2D(Collision2D col)
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "obstacle")
            {
                print("you died!");
                _audioSource.PlayOneShot(DieClip);
                respawn();
                }
                
                if (col.gameObject.tag == "checkpoint")
                {
                    if (repawnPosision != col.transform.position)
                    {
                        _audioSource.PlayOneShot(CheckPointClip);
                    }
                    repawnPosision = new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z);
                }
    }

    void respawn()
    {
        player.transform.position = repawnPosision;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}


