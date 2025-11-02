using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : AbstractObject
{  
    private void Update()
    {
        if (!active)
            spriteRenderer.enabled = false;

        if (active)
            spriteRenderer.enabled = true;
    }
}
