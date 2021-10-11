using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public GameObject prefab;
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        DoShoot();
    }

    void DoJump()
    { 
        bool IsGrounded = false;
        float xpos = transform.position.x;
        float ypos = transform.position.y;
        float yvelocity = rb.velocity.y;
        float xvelocity = rb.velocity.x;

        Helper.DoRayCollisionCheck(character, xpos, ypos, IsGrounded);
       

        // check for jump
        if (Input.GetKeyDown("space"))
        {
            Helper.SetVelocity(gameObject, 0, 10);

        }


    }

    void DoMove()
    {
        // stop player sliding when not pressing left or right
        anim.SetBool("Walk", false);
        // check for moving left
        if (Input.GetKey("a"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", true);
            Helper.FlipSprite(gameObject, true);
            Helper.SetVelocity(character, -6, 0);
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", false);
            Helper.FlipSprite(gameObject, false);    //flip sprite left
            Helper.SetVelocity(character, 6, 0);
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
