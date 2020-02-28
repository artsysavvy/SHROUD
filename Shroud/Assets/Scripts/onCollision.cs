using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    // This script will house all of the methods to be invoked when a collision with this object and the player starts and ends

    // These bools will be checkable boxes in the inspector to toggle specific behavior
    public bool doLightUp;

    private bool increaseLightIntensity = false;

    public void OnCollideStart()
    {
        if (doLightUp)
        {
            increaseLightIntensity = true;
        }
    }

    public void OnCollideEnd()
    {
        if (doLightUp)
        {
            increaseLightIntensity = false;
        }
    }

    public void Update()
    {
        Light light = gameObject.GetComponent<Light>();
        if (increaseLightIntensity)
        {
            if (light.range < 10)
            {
                light.range += 0.1f;
            }
        }
        else
        {
            if (light.range > 0)
            {
                light.range -= 0.25f;
            }
        }
    }
}
