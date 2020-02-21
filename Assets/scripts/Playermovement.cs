using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public float speed;      
    public float jumpForce;
    public float DashDownForce;
    private Rigidbody2D rb2d;
    private bool Jumping;
    public static int JumpLeft = 3;
    public Animator anim;
    private bool buttonPressed;
    public bool usesKeyboard = false;

    public float moveHorizontal;

    public ParticleSystem JumpParticleSystem;

    
    //audio
    private AudioSource _audioSource;

    public AudioClip JumpClip;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetKeyboard(true);
            jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetKeyboard(true);
            DashDown();
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //collects input form the player
        if (usesKeyboard)
        {
            moveHorizontal = Input.GetAxis ("Horizontal");    
        }
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        if (rb2d.velocity.y < 0) {
            GetComponent<Animator>().SetBool("fallingDown", true);
            GetComponent<Animator>().SetBool("onGround", false);
        }
    }

    public void DashDown()
    {
        print("going Down!");
        rb2d.AddForce(new Vector2 (rb2d.velocity.x, DashDownForce));
    }

    public void jump() {
        if (JumpLeft > 0) {
                GetComponent<Animator>().SetTrigger("spacebarPressed");
                Jumping = true;
                JumpLeft--;
                rb2d.AddForce(new Vector2 (rb2d.velocity.x, jumpForce));
                _audioSource.PlayOneShot(JumpClip);
                JumpParticleSystem.Play();
        }
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "ground") {
            GetComponent<Animator>().SetBool("onGround", true);
            GetComponent<Animator>().SetBool("fallingDown", false);
            JumpLeft = 3;
            Jumping = false;
        } 
        
    }


    public void left()
    {
        moveHorizontal = -0.7f;
    }

    public void right()
    {
        moveHorizontal = 0.7f;
        moveHorizontal = 1f;
    }

    public void ResetMoveHorizontal()
    {
        moveHorizontal = 0;
    }

    public void SetKeyboard(bool Use)
    {
        usesKeyboard = Use;
    }
}
