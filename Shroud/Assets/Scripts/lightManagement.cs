﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LightGlobals
{
    public static bool levelStarted;
    public static bool doorShown;
    public static bool playerShown;
}

public class lightManagement : MonoBehaviour
{
    private const float TIME_UNTIL_DARKNESS = 1.5f;
    private float timeProgress;

    private void Awake()
    {
        RenderSettings.ambientLight = Color.white;
        LightGlobals.levelStarted = false;
    }

    private void Update()
    {
        // Waiting until the player has been shown on the screen
        if (LightGlobals.playerShown)
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
                else
                {
                    LightGlobals.levelStarted = true;
                }
            }
        }
    }
}
