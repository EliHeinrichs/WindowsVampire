using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Pawn playerPawn;
    public PlayerController playerController;
    
    

    void Start()
    {
        //Setting the pawn for the player to control
        playerController.Possess(playerPawn);
       
    }
}
