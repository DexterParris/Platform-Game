using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject prefab;
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
        DoShoot();
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
        // check for moving left
        if (Input.GetKey("a"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            Flipper.FlipSprite(gameObject, true);
            velocity.x = -6;
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", false);
            anim.SetBool("right", true);
            Flipper.FlipSprite(gameObject, false);    //flip sprite left
            velocity.x = 6;
        }
        rb.velocity = velocity;

    }


    void DoShoot()
    {
        if (Input.GetKey("s"))
        {
            float xpos = transform.position.x;
            float ypos = transform.position.y + 1;
            float xvel = 0;
            float yvel = 0;
        
            GameObject instance = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity);

            if (anim.GetBool("left") == true)
            {
                xvel = -7;
                Flipper.FlipSprite(instance, true);

            }
            else
            {
                xvel = 7;
                Flipper.FlipSprite(instance, false);
            }
            
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(xvel, yvel, 0);

        }
    }
}
