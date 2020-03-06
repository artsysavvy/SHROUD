using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Adding the player and door through the inspector
    public GameObject player;
    public GameObject door;

    private bool waitedOnLevelLoad;
    private float levelLoadWaitTimer;
    private const float LEVEL_LOAD_TIME = 1.5f;

    private bool doorWaitStart;
    private float doorWaitTimer;
    private const float DOOR_WAIT_TIME = 1;

    private const float CAMERA_SCROLL_FACTOR = 3.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        LightGlobals.doorShown = false;
        doorWaitStart = false;
        LightGlobals.playerShown = false;
        waitedOnLevelLoad = false;
    }

    // Update is called once per frame
    void Update()
    {
        Camera mainCamera = gameObject.GetComponent<Camera>();

        if (!waitedOnLevelLoad)
        {
            if (levelLoadWaitTimer >= LEVEL_LOAD_TIME)
            {
                waitedOnLevelLoad = true;
            }
            levelLoadWaitTimer += Time.deltaTime;
        }
        else if (!LightGlobals.doorShown)
        {
            // Checking if the door is not in the bounds of the screen
            if (door.transform.position.x > mainCamera.transform.position.x + 12)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + Time.deltaTime * CAMERA_SCROLL_FACTOR, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            else if (door.transform.position.x < mainCamera.transform.position.x - 12)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x - Time.deltaTime * CAMERA_SCROLL_FACTOR, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            // Starting the door wait timer
            else if (doorWaitStart)
            {
                // If the timer ends, move the camera towards the player
                doorWaitTimer += Time.deltaTime;
                if (doorWaitTimer >= DOOR_WAIT_TIME)
                {
                    LightGlobals.doorShown = true;
                }
            }
            else
            {
                doorWaitStart = true;
            }
        }
        else
        {
            // Checking if the player is on the screen
            if (player.transform.position.x > mainCamera.transform.position.x + 13)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + Time.deltaTime * CAMERA_SCROLL_FACTOR, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            else if (player.transform.position.x < mainCamera.transform.position.x - 13)
            {
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x - Time.deltaTime * CAMERA_SCROLL_FACTOR, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
            else
            {
                LightGlobals.playerShown = true;
            }
        }
    }
}
