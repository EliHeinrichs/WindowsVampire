using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorAI : MonoBehaviour
{
    public enum states
    {
        Searching,
        Chasing,
    }
    [Header("Adjustable Stats")]
    public float viewDistance;
    public float viewAngle;
    public float speed;
    [Header("Current state")]
    public states currentState;

    private Vector2 moveDirection;
    private Vector2 lastSeenPosition;
    
      
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchStates(states changeState)
    {
        
        
    }
    

}
