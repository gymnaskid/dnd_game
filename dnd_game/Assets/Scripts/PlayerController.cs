using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public vars
    public float moveSpeed;


    //private vars
    private Rigidbody2D myRigidBody;

    private Animator anim;

    private Vector2 moveInput;
    private Vector2 lastMove;

    private bool playerMoving;
    private static bool playerExists;

    
    // Start is called before the first frame update
    void Start()
    {
        //check to see if we already have a player 
            //this ensures that any data we want to take through scenes wont be lost as we will keep the player object from being destroyed
        if(!playerExists)
        {
            playerExists = true; //we now have a player
            myRigidBody = GetComponent<Rigidbody2D>(); //set up the rigid body that we will use to move around the world
            anim = GetComponent<Animator>(); //this will allow us to chenge what animations are being done
            DontDestroyOnLoad(transform.gameObject); //this makes it so the object wont be destroyed when moving from scene to scene

            lastMove = new Vector2(0,- 1); //make sur ethe player starts facing down
        }
        else //if we do destroy the one that is trying to be created
        {
            Destroy(gameObject); //destroy the newly created game object
        }
        
    }

    // Update is called once per frame
    void Update()
    {


        //if w,a,s,d/ arrow keys are being pushed move the player
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (moveInput != Vector2.zero) //if w,a,s,d are being pressed move the player
        {
            myRigidBody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
            playerMoving = true;
            lastMove = moveInput;
        }
        else //if no movement keys are being pressed stop the player form moving
        {
            //this ensures that you dont slide accross the screen when you dont want to move
            myRigidBody.velocity = Vector2.zero;
            playerMoving = false;
        }

    }
}
