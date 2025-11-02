using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the player
// This script is a subclass of Controller
// Overrides GetMoveInput to take input from the player
public class PlayerController : Controller
{
    //gets input and returns it as a vector
    protected override Vector2 GetMoveInput()
    {      
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        return new Vector2(x, y);
    }

}
