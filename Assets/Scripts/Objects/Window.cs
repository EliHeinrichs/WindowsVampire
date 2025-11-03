using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : AbstractObject
{
    private float interactRadius = 1.5f;

    public LayerMask layerMask;
    private void Update()
    {
        CheckIfPlayerInRange();
        if(active)
            spriteRenderer.color = Color.red;
        else
            spriteRenderer.color = Color.black;
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, interactRadius, layerMask);

        if (collider != null && Input.GetKeyDown(KeyCode.E))
        {           
            UIManager.instance.UpdateCurrentActiveMiniGame(UIManager.instance.windowMiniGame);
        }
    }
    
}
