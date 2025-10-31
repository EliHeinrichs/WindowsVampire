using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : AbstractObject
{
    public GameObject minigame;

    private float interactRadius = 1.5f;

    public LayerMask layerMask;
    private void Update()
    {
        CheckIfPlayerInRange();
        if (active)
            spriteRenderer.color = Color.yellow;
        else
            spriteRenderer.color = Color.black;
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, interactRadius, layerMask);

        if (collider != null && Input.GetKeyDown(KeyCode.E))
        {
            minigame.SetActive(true);
        }
    }
    
}
