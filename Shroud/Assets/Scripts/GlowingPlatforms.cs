using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingPlatforms : MonoBehaviour
{
    int glow = 100;

    // Start is called before the first frame update
    void Start()
    {
        /*halo*//* = GetComponent<Halo>();*/
    }

    // Update is called once per frame
    void Update()
    {
        // if it's being stepped on, make the halo appear
        if (glow > 0)
        {
            //halo.size = glow;
            //glow--;
        }
    }
}
