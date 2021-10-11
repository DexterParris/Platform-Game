using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    public float playerpos;
    public float enemypos;

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
        DoMove();
    }

    void DoMove()
    {

        playerpos = GameObject.Find("Player").transform.position.x;
        enemypos = transform.position.x;

        Vector2 velocity = rb.velocity;
        float distance = enemypos - playerpos;

        // stop player sliding when not pressing left or right
        velocity.x = 0;
        anim.SetBool("Walk", false);
        // check for moving left
        if (distance <10 && distance >1.5f)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", true);
            Helper.FlipSprite(gameObject, true);
            velocity.x = -4;
            distance = enemypos - playerpos;
        }

        // check for moving right
        if (distance >-10 && distance <-1.5f) 
        {
            anim.SetBool("Walk", true);
            anim.SetBool("left", false);
            Helper.FlipSprite(gameObject, false);
            velocity.x = 4;
            distance = enemypos - playerpos;
        }
        rb.velocity = velocity;

    }
}