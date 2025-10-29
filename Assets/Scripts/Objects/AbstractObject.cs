using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class AbstractObject : MonoBehaviour
{
    public enum Side { North, East, South, West}

    public Side side;

    public bool active;

    private new BoxCollider2D collider;

    public virtual void ToggleActive()
    {
        active = !active;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ToggleActive();
    }

}
