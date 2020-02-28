using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    const float SPEED = 5f;   //A constant for player speed
    const float JUMP_HEIGHT = 7f;  //A constant for jump height

    public bool isGrounded = false;   //A bool to track whether or not the player is in the air

    private SpriteRenderer SR; 

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();           
    }

    /// <summary>
    /// Function to calculate and apply player movement
    /// </summary>
    void Movement()
    {
        //Checks for movement input along the horizontal axis and updates the players position accordingly
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * SPEED;


        //Checks if space or w is pressed and uses the rigid body to jump
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JUMP_HEIGHT), ForceMode2D.Impulse);
        }

        //Code to Flip Sprite Based on Direction
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (SR != null)
            {
                SR.flipX = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (SR != null)
            {
                SR.flipX = false;
            }
        }

    }
}
