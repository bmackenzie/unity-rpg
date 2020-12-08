using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerController : Entity
{
    public Rigidbody2D rb2d;

    public float moveSpeed;

    public Animator myAnim;

    public static PlayerController instance;

    public string areaTransitionName;

    public bool canMove = true;

    Vector2 movement;

    Vector2 lastMove;

    GameObject dialogueRunner;


    // Start is called before the first frame update
    void Start()
    {
        //Ensures only one instance of the player can exist. if you have a player load script, this needs to execute before it or it blows up the player. Also not movement related
        if (instance == null)
        {
            instance = this;
        }
        //checks before deletion that any instance isn't this object
        else if (instance != this)
        {
                Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        //move input
        movement.x =  Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // prevents diagonal movement, needs to be amended so that you keep going in the direction you were going, the reason this doesn't work is because rb2d is staying the same, so lastmove references the position the player has moved to already
        if (movement.x != 0 ^ movement.y != 0)
        {
            //move the character, set last move direction, checks if canMove is true to stop movement during dialog and other interactions
            if (canMove)
            {
                lastMove = movement;
                rb2d.MovePosition(rb2d.position + lastMove * moveSpeed * Time.fixedDeltaTime);
            }
            //choose an animation to play, checks canMove to prevent animation changing while movement is locked
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y) && canMove)
            {
                myAnim.SetFloat("moveX", movement.x);
                myAnim.SetFloat("moveY", 0f);
                myAnim.SetFloat("lastMoveX", movement.x);
                myAnim.SetFloat("lastMoveY", 0f);
            }
            else if (Mathf.Abs(movement.y) > Mathf.Abs(movement.x) && canMove)
            {
                myAnim.SetFloat("moveY", movement.y);
                myAnim.SetFloat("moveX", 0f);
                myAnim.SetFloat("lastMoveY", movement.y);
                myAnim.SetFloat("lastMoveX", 0f);
            }
        }
        else if (movement.x != 0 && movement.y != 0 && (movement.x == lastMove.x || movement.y == lastMove.y))
        {
            //keeps the character moving in the same direction if the user holds a second key
            rb2d.MovePosition(rb2d.position + lastMove * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            //halts movement
            rb2d.MovePosition(rb2d.position);
            //return to idle animation, reset lastMove
            myAnim.SetFloat("moveX", 0);
            myAnim.SetFloat("moveY", 0);
            lastMove = new Vector2(0, 0);
        }

        //stop the player from leaving the map, function from entity.cs
        setClamp(.5f, 1f);

    }
}