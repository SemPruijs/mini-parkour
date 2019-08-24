using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public float speed;      
    public float jumpForce;         
    private Rigidbody2D rb2d;
    private bool Jumping;
    public static int JumpLeft = 3;
    public Animator anim;
    private bool buttonPressed;

    public float moveHorizontal;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim.GetComponent<Animator>();
       
    }

    void Update() {
        jump();

    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //collects input form the player
        moveHorizontal = Input.GetAxis ("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        if (rb2d.velocity.y < 0) {
            GetComponent<Animator>().SetBool("fallingDown", true);
            GetComponent<Animator>().SetBool("onGround", false);
        }

    

        
        
    }

    void jump() {
        if (JumpLeft > 0) {
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) {
                GetComponent<Animator>().SetTrigger("spacebarPressed");
                Jumping = true;
                JumpLeft--;
                rb2d.AddForce(new Vector2 (rb2d.velocity.x, jumpForce));
            }
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



    public void jumpButton() {
        if (JumpLeft > 0) {
            GetComponent<Animator>().SetTrigger("spacebarPressed");
            Jumping = true;
            JumpLeft--;
            rb2d.AddForce(new Vector2 (rb2d.velocity.x, jumpForce));
        }
    }

    public void leftButtonDown() {
        buttonPressed = true;
        if (buttonPressed) {
             moveHorizontal = -1.0f;
        }
    }

    public void buttonUp() {
        buttonPressed = false;
        moveHorizontal = 0.0f;
        print("hey");
    }
    
    public void rightButtonDown() {
        buttonPressed = true;
        if (buttonPressed) {
             moveHorizontal = 1.0f;
        }
    }


}
