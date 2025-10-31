using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireExit : MonoBehaviour
{
    public enum Side { North, East, South, West }
    public Side side;
    public LightSwitch[] lights;
    public bool reachedEnd = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TurnOnLightsOnSameSide();
        reachedEnd = true;
    }

    private void TurnOnLightsOnSameSide()
    {
        switch (side)
        {
            case Side.North:
                foreach (LightSwitch light in lights)
                {
                    if(light.side == AbstractObject.Side.North)
                        light.active = true;
                }
                break;

            case Side.East:
                foreach (LightSwitch light in lights)
                {
                    if (light.side == AbstractObject.Side.East)
                        light.active = true;
                }
                break;

            case Side.South:
                foreach (LightSwitch light in lights)
                {
                    if (light.side == AbstractObject.Side.South)
                        light.active = true;
                }
                break;

            case Side.West:
                foreach (LightSwitch light in lights)
                {
                    if (light.side == AbstractObject.Side.West)
                        light.active = true;
                }
                break;

        }

    }
}
