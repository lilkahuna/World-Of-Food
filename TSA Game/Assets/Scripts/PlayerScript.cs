using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour

{
    int speed = 5;
    Rigidbody2D playerRigidbody;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public bool isFacingRight = true;

    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        

        float horizontalMove = Input.GetAxis("KeyHorizontal");
        float verticalMove = Input.GetAxis("KeyVertical");

        if (horizontalMove != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        
        else if (verticalMove != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(verticalMove));
        }


        Vector2 movement = new Vector2(horizontalMove, verticalMove);

        playerRigidbody.velocity = movement * speed;
        
        //playerRigidbody.velocity = new Vector2(horizontalInput.x * playerSpeed, playerRigidbody.velocity.y);

        if (horizontalMove > 0)
        {
            isFacingRight = true;
            spriteRenderer.flipX = false;
        }

        else if (horizontalMove < 0)
        {
            isFacingRight = false;
            spriteRenderer.flipX = true;
        }

        else
        {
            return;
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Collectible")
            {
                Destroy(other.gameObject);
            }
    }
}