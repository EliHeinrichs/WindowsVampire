using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Pawn playerPawn;
    public PlayerController playerController;
    public WireController wireController;
   
    void Start()
    {
        //Setting the pawn for the player to control
        if(playerController != null)
            playerController.Possess(playerPawn);
        
        if(wireController != null)
            wireController.Possess(playerPawn);
    }
}
