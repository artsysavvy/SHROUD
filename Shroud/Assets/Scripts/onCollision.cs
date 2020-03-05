using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    // This script will house all of the methods to be invoked when a collision with this object and the player starts and ends

    // These bools will be checkable boxes in the inspector to toggle specific behavior
    public bool doLightUp;

    //Public variables for SFX
    public AudioSource land1;
    public AudioSource land2;
    public AudioSource land3;

    private bool increaseLightIntensity = false;

    public void Start()
    {
        Light spotlight = gameObject.GetComponentInChildren<Light>();
        spotlight.spotAngle = 100 * gameObject.transform.localScale.x;
        spotlight.range = 10 * gameObject.transform.localScale.x;
    }

    public void OnCollideStart()
    {
        if (doLightUp)
        {
            increaseLightIntensity = true;
        }

        //Finds random number
        int rand = Random.Range(0, 2);

        //Based on number
        switch (rand)
        {
            //Play different sound effects
            case 0:
                land1.Play();
                break;

            case 1:
                land2.Play();
                break;

            case 3:
                land3.Play();
                break;
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
        Light light = gameObject.GetComponentInChildren<Light>();
        if (increaseLightIntensity)
        {
            if (light.intensity < 1)
            {
                light.intensity += 0.02f;
            }
        }
        else
        {
            if (light.intensity > 0)
            {
                light.intensity -= 0.02f;
            }
        }
    }
}
