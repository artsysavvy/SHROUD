using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{

    //This script exists to keep the player from infintely jumping

    GameObject Player;   //Variable for the player object

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Checks to see if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            Player.GetComponent<playerScript>().isGrounded = true;
            Player.GetComponent<playerScript>().changeStates(0);
        }
        // Calling the collision logic for the object that was collided with
        if (collision.collider.gameObject.GetComponent<onCollision>())
        {
            collision.collider.gameObject.GetComponent<onCollision>().OnCollideStart();
        }
    }

    //Checks to see if the player is in the air
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            Player.GetComponent<playerScript>().isGrounded = false;
        }
        // Calling the collision logic for the object that was collided with
        if (collision.collider.gameObject.GetComponent<onCollision>())
        {
            collision.collider.gameObject.GetComponent<onCollision>().OnCollideEnd();
        }
    }
}
