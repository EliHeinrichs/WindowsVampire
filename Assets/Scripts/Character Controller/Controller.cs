using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    
    protected Pawn pawn;

    private bool movementEnabled = true;

    //Setting the pawn and giving it a controller
    public virtual void Possess(Pawn pawnToControl)
    {
        pawn = pawnToControl;
        pawn.SetController(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (pawn == null)
        {
            Debug.LogWarning(gameObject.name + " has no Pawn assigned!," + this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled) 
            Move();
    }

    public void ToggleMovement(bool toggle)
    {
        movementEnabled = toggle;
    }

    //Getting a vector from GetMoveInput and using that to move the pawn
    private void Move()
    {
        Vector2 moveInput = GetMoveInput();
        pawn.Move(moveInput);
    }

    //protected because only subclasses need to access
    protected abstract Vector2 GetMoveInput();
}
