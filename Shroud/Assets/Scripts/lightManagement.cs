﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class lightGlobals
{
    public static bool enableSpotlights;
}

public class lightManagement : MonoBehaviour
{
    private const float TIME_UNTIL_DARKNESS = 3;
    private float timeProgress;

    private void Awake()
    {
        RenderSettings.ambientLight = Color.white;
    }

    private void Update()
    {
        // Waiting until the time is reached
        timeProgress += Time.deltaTime;
        if (timeProgress >= TIME_UNTIL_DARKNESS)
        {
            // Darkening the scene
            if (RenderSettings.ambientLight != Color.black)
            {
                Color oldColor = RenderSettings.ambientLight;
                RenderSettings.ambientLight = new Color(oldColor.r - 0.01f, oldColor.g - 0.01f, oldColor.b - 0.01f);
            }
        }
    }
}
