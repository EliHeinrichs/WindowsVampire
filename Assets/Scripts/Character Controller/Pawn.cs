using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    protected Controller controller;
    
    public float speed = 5f;

    //setting the controller that controls the pawn
    public void SetController(Controller newController)
    {
        controller = newController;
    }

    //Moves the pawn using the Vector2 parameter
    public void Move(Vector2 input)
    {
        Vector2 movement = new Vector2(input.x, input.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
