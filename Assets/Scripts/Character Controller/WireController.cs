using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the player
// This script is a subclass of Controller
// Overrides GetMoveInput to take input from the player
public class WireController : Controller
{
    //gets input and returns it as a vector
    private float verticalMovement;

    private float horizontalMovement;

    protected override Vector2 GetMoveInput()
    {      
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x > 0)
        {
            horizontalMovement = 1;
            verticalMovement = 0;
        }   
            
        if (x < 0)
        {
            horizontalMovement = -1;
            verticalMovement = 0;
        }
            
        if (y > 0)
        {
            verticalMovement = 1;
            horizontalMovement = 0;
        }
            
        if (y < 0)
        {
            verticalMovement = -1;
            horizontalMovement = 0;
        }          

        return new Vector2(horizontalMovement, verticalMovement);
    }

    public void ResetMovementFloats()
    {
        verticalMovement = 0;
        horizontalMovement = 0;
    }

}
