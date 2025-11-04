using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    private float interactRadius = 1.5f;

    public LayerMask layerMask;
    private void Update()
    {
        CheckIfPlayerInRange();
        
        
      
    }

    private void CheckIfPlayerInRange()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, interactRadius, layerMask);

        if (collider != null && Input.GetKeyDown(KeyCode.E))
        {
            UIManager.instance.PlayerEnabled(false);
            UIManager.instance.UpdateCurrentActiveMiniGame(UIManager.instance.closetMiniGame, gameObject);
        }
    }
    
    
    
}
