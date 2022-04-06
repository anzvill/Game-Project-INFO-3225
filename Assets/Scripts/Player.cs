//Character movements

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public Transform groundCheck;
    public LayerMask groundlayer;


    float xMove, yMove;
    bool isGrounded;    

    //variables to call sprites
    Vector2 targetPos;
    Rigidbody2D rbody;
    SpriteRenderer srender;



    private void Awake(){
        rbody = GetComponent<Rigidbody2D>();
        srender = GetComponent<SpriteRenderer>();

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            if (isGrounded){
                playerJump();
            }
        }
        

        
    }

    //update movement of character using x y axis , use wasd, arrow keys
    private void FixedUpdate(){

        
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        transform.Translate(xMove * moveSpeed,0, 0);

        platformMove();
        flipPlayer();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundlayer);
    }

    void platformMove(){
        rbody.velocity = new Vector2(moveSpeed * xMove, rbody.velocity.y);
    }

    void playerJump(){
        rbody.velocity = Vector2.up * jumpForce;

    }

    //flip player image to left when faces left
    void flipPlayer(){

        //check if less is less than 0.1, flip character
        if (rbody.velocity.x < -0.1f){
            srender.flipX = true;
        }
        else if (rbody.velocity.x > 0.1f){
            srender.flipX = false;
        }

    }
}
