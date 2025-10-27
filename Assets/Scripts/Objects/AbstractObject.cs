using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractObject : MonoBehaviour
{
    public enum Side { North, East, South, West}

    public Side side;

    public bool active;

    public virtual void ToggleActive()
    {
        active = !active;
    }
}
