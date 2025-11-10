using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{ 
    private bool inRange = false;

    public LayerMask layerMask;
    private void Update()
    {
        CheckIfPlayerInRange();
        
        
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }

    private void CheckIfPlayerInRange()
    {       

        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            UIManager.instance.PlayerEnabled(false);
            UIManager.instance.UpdateCurrentActiveMiniGame(UIManager.instance.closetMiniGame, gameObject);
        }
    }
    
    
    
}
