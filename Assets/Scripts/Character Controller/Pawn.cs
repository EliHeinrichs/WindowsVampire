using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    protected Controller controller;
    
    public float speed = 5f;

    public LayerMask wallMask;

    public BoxCollider2D hitbox;

    public Vector2 defaultPosition;

    //setting the controller that controls the pawn
    public void SetController(Controller newController)
    {
        controller = newController;
    }

    //Moves the pawn using the Vector2 parameter
    public void Move(Vector2 input)
    {
        Vector2 direction = input.normalized;

        if (direction != Vector2.zero)        
            TryMove(direction);
        
    }
    
    private void TryMove(Vector2 direction)
    {
        float distance = speed * Time.deltaTime;

        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = currentPosition + direction * distance;

        Collider2D hit = Physics2D.OverlapBox(targetPosition, hitbox.bounds.size, 0f, wallMask);
        if (hit == null)
        {
            transform.Translate(direction * distance);
        }                            
    }

    public void ResetPosition()
    {
        transform.position = defaultPosition;
    }
}
