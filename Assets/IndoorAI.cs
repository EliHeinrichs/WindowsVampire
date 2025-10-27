using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorAI : MonoBehaviour
{
    public enum states
    {
        // Wandering is when the thing has no clue to where the player is
        Wandering,
        // searching makes the thing walk around the last spotted area for a time
        Searching,
        // chasing is called when the player is in active vision of the thing
        Chasing,
        Mimic,
    }
    
    [Header("Adjustable Stats")]
    public float viewDistance;

    public float lookAngleRange;
    public float speed;
    public LayerMask hitLayer;
    public LayerMask playerLayer;
    public Transform[] checkPoints;
    public bool DEBUGMODE;
    
    [Header("Current state")]
    public states currentState;

    // current move dir
    private Vector2 moveDirection;
    // stores last seen position
    private Vector2 lastSeenPosition;
    private int currentCheckPointIndex = 0;
    private float distToPoint;

    // is current angle that the thing is looking at
    private float currentLookRotation;
    
      
    // Start is called before the first frame update
    void Start()
    {
        currentState = states.Wandering;
    }

    // Update is called once per frame
    void Update()
    {
      
        HandleCurrentState();
        
    }

    Transform GetCurrentCheckPoint()
    {
       

        if (distToPoint < 0.1)
        {
            
            currentCheckPointIndex = (currentCheckPointIndex >= checkPoints.Length -1) ? 0 :  currentCheckPointIndex += 1;
            
          
            
        }
        
        return checkPoints[currentCheckPointIndex];


    }

    void SwitchStates(states changeState)
    {
        currentState = changeState;
    }

    void HandleCurrentState()
    {
        switch (currentState)
        {
          case states.Wandering:
              UpdateWandering();    
              break;
          case states.Searching:
              UpdateSearching();
              break;
          case states.Chasing:
              UpdateChasing();
              break;
          case states.Mimic:
              UpdateMimic();
              break;
        }
    }



    void UpdateWandering()
    {


    }


    void UpdateSearching()
    {
        
        
        
    }

    void UpdateChasing()
    {
        
        
    }

    void UpdateMimic()
    {
        
        
        
    }
 
}
