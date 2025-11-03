using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerController : MonoBehaviour
{
    public Pawn wirePawn;   
    public WireController wireController;

    public TrailRenderer wireTrail;
    public WireExit[] WireExits;
    public PlayerController playerController;
    void Start()
    {                  
        
    }

    void Update()
    {
        ListenForInput();
        CheckIfReachedEnd();
    }

    private void CheckIfReachedEnd()
    {
        foreach (WireExit wireExits in WireExits)
        {
            if (wireExits.reachedEnd)
            {
                 UIManager.instance.DisableMiniGame();
            
            }               
        }
    }

    void OnEnable()
    {
        StartGame();
    }
    
    
    
    public void StartGame()
    {
        playerController.ToggleMovement(false);
        foreach (WireExit wireExits in WireExits)
        {
            if (wireExits.reachedEnd)
                wireExits.reachedEnd = false;
        }
        

        if (wireController != null)
            wireController.Possess(wirePawn);

        wirePawn.ResetPosition();
        wireController.ResetMovementFloats();
        wireTrail.Clear();
    }

    private void ListenForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            UIManager.instance.DisableMiniGame();
    
        }
    } 
}
