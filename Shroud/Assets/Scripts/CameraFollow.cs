using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Adding the player and door through the inspector
    public GameObject player;
    public GameObject door;

    private bool doorWaitStart;
    
    // Start is called before the first frame update
    void Start()
    {
        LightGlobals.doorShown = false;
        doorWaitStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        Camera mainCamera = gameObject.GetComponent<Camera>();

        // Checking if the door is not in the bounds of the screen
        if (door.transform.position.x > mainCamera.transform.position.x - 5 && !LightGlobals.doorShown)
        {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + 0.05f, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }
}
