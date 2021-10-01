using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add this in update()
        // this sets the variable to 10
        // From our condition we set up above we said that if "speed">5 then set the animation to "player_Walk"
        DoJump();
        DoMove();

    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("space"))
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 7f;    // give the player a velocity of 5 in the y axis

            }
        }

        rb.velocity = velocity;

    }

    void DoMove()
    {
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;
        anim.SetBool("Walk", false);
        anim.SetBool("left", false);
        // check for moving left
        if (Input.GetKey("a"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", true);
            velocity.x = -6;
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            anim.SetBool("Walk", true);
            velocity.x = 6;
        }
        rb.velocity = velocity;

    }

    void FlipSpriteLeft( bool left )
    {
        if( left == true )
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}