using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : AbstractObject
{
    public GameObject minigame;

    private float interactRadius = 1.5f;

    public LayerMask layerMask;

    public BreakerController breakerController;
    private void Update()
    {
        CheckIfPlayerInRange();
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, interactRadius, layerMask);

        if (collider != null && Input.GetKeyDown(KeyCode.E))
        {
            breakerController.StartGame();
        }
    }

}
