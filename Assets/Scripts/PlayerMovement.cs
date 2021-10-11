using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject prefab;
    public GameObject velobject;
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
        if (Input.GetKeyDown("space"))
        {
            if (velocity.y < 0.01f)
            {
                yvelocity = 7f;    // give the player a velocity of 7 in the y axis
                Helper.SetVelocity(velobject, xvelocity, yvelocity);
            }
        }

        rb.velocity = velocity;

    }

    void DoMove()
    {
        float xvelocity = 0;
        float yvelocity = 0;
        Helper.SetVelocity(velobject, xvelocity, yvelocity);
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        xvelocity = 0;
        anim.SetBool("Walk", false);
        // check for moving left
        if (Input.GetKey("a"))
        {
            xvelocity = -6;
            yvelocity = 0;
            anim.SetBool("Walk", true);
            anim.SetBool("left", true);
            Helper.FlipSprite(gameObject, true);
            Helper.SetVelocity(velobject, xvelocity, yvelocity);
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            xvelocity = 6;
            yvelocity = 0;
            anim.SetBool("Walk", true);
            anim.SetBool("left", false);
            Helper.FlipSprite(gameObject, false);    //flip sprite left
            Helper.SetVelocity(velobject, xvelocity, yvelocity);
        }

    }


    void DoShoot()
    {

        if (Input.GetKeyDown("s"))
        {
            float xpos = transform.position.x;
            float ypos = transform.position.y;
            float xvel = 7;
            float yvel = 0;

            Helper.MakeBullet(prefab, xpos + 1, ypos + 1, xvel, yvel, anim.GetBool("left")); //instantiate the object using the instantiation method in the helper.cs script

        }
    }

}
