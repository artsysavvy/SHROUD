using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Inspector fields
    //public int sceneNumToSwitchTo;

    private bool doorEnabled;
    private const KeyCode DOOR_ENTER_KEY = KeyCode.E;

    public bool changeScene = false;

    public static Door instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Only running the door logic if the door is enabled
        if (doorEnabled)
        {
            // Checking for the door entering key being pressed
            if (Input.GetKeyDown(DOOR_ENTER_KEY))
            {
                Debug.Log("super gamer moment");
                // Moving to the next scene if it exists
                /*if (sceneNumToSwitchTo != -1 && sceneNumToSwitchTo < SceneManager.sceneCount)
                {
                    SceneManager.LoadScene(sceneNumToSwitchTo);
                }*/

                changeScene = true;
            }
        }
    }

    // Methods that deal with the player colliding with the door
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doorEnabled = true;
            Debug.Log("Gamer Moment");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doorEnabled = false;
            Debug.Log("gaming moment");
        }
    }
}
