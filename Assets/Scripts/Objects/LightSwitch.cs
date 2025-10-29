using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : AbstractObject
{
    public SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (!active)
            spriteRenderer.color = Color.black;

        if (active)
            spriteRenderer.color = Color.green;
    }
}
