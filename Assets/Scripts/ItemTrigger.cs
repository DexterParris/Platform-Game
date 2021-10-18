using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float playerpos;

    void DoMove()
    {
        float itempos;
        playerpos = GameObject.FindWithTag("Player").transform.position.x;
        itempos = transform.position.x;

        Vector2 velocity = rb.velocity;
        float distance = itempos - playerpos;

        // stop player sliding when not pressing left or right
        velocity.x = 0;
        // check for moving left
        if (distance < 20 && distance > 0.5f)
        {
            velocity.x = -5;
            distance = itempos - playerpos;
        }

        // check for moving right
        if (distance > -20 && distance < -0.5f)
        {
            velocity.x = 5;
            distance = itempos - playerpos;
        }
        rb.velocity = velocity;
    }

        // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject, 0.2f);
        }
    }

    void Update()
    {
        DoMove();
    }

}
