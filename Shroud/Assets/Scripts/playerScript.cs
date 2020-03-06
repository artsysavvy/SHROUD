using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    const float SPEED = 5f;   //A constant for player speed
    const float JUMP_HEIGHT = 7f;  //A constant for jump height

    public bool isGrounded = false;   //A bool to track whether or not the player is in the air
    public Vector3 startingPosition;  //The Starting Position of the Player for the Level

    private SpriteRenderer SR;
    public AudioSource footsteps;

    PlayerStates currentState;

    //animationStates
    enum PlayerStates
    {
        Idle,
        RunningRight,
        RunningLeft,
        JumpRight,
        JumpLeft
    }

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Updating status of lighting
        if (LightGlobals.levelStarted)
        {
            gameObject.GetComponentInChildren<Light>().intensity = 1.5f;
            // Only allowing player movement once the level has started
            Movement();
        }
        else
        {
            gameObject.GetComponentInChildren<Light>().intensity = 0;
        }
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

        // Footstep code
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!footsteps.isPlaying)
            {
                footsteps.Play();
            }
        }
        else
        {
            footsteps.Stop();
        }

        //Code to check if the player has fallen.
        if (transform.position.y <= -10)
        {
            transform.position = startingPosition;
        }

        else
        {
            //Stop playing sound
            footsteps.Stop();
        }

    }
    /*
    void changeStates(state)
    {
        
    }
    */
}
