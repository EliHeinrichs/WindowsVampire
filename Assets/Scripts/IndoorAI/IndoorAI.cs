using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IndoorAI : MonoBehaviour
{
    public enum states
    {
        // Wandering is when the thing has no clue to where the player is
        Wandering,
        
        // chasing is called when the player is in active vision of the thing
        Chasing,
        
        Idle,
        
    }
    
    [Header("Adjustable Stats")]
    public float viewDistance;
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
    private int currentCheckPointIndex = 0;
    private float distToPoint;
    
    private Rigidbody2D rb;
    public Transform playerTransform;

    private Vector2[] checkDirs = {Vector2.right, Vector2.up, Vector2.down, Vector2.left};
    
    public float chaseDistance;




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Dead");
        }
    }

    
      
    // Start is called before the first frame update
    void Start()
    {
        currentState = states.Wandering;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
        HandleCurrentState();
        
        
    }

   
    Transform UpdateCurrentCheckPoint()
    {


         currentCheckPointIndex = (currentCheckPointIndex >= checkPoints.Length -1) ? 0 :  currentCheckPointIndex += 1;
        
        
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
          case states.Chasing:
              UpdateChasing();
              break;
          case states.Idle:
              UpdateIdle();
              break;
          
        }
    }

 


    void UpdateWandering()
    {
        
            // if nothing is hit, then move towards the currentclick
        
            
            RaycastHit2D hitPlayer = Physics2D.CircleCast(rb.position, chaseDistance, moveDirection ,0f,playerLayer);
            if (hitPlayer)
            {
                SwitchStates(states.Chasing);
            }
            
        
        if (DEBUGMODE)
        {
            Debug . DrawLine (rb. position , checkPoints[currentCheckPointIndex].position , Color . black);
        }
        
        if (DEBUGMODE)
        {
            Debug . DrawRay (rb . position , moveDirection * viewDistance , Color . cyan);
        }

        distToPoint = Vector2.Distance(rb.position, checkPoints[currentCheckPointIndex].position);
        // sphere casts to see if any obstacles are hit
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, viewDistance, moveDirection ,1f,hitLayer);
        
       RaycastHit2D hitObjective = Physics2D.Raycast(rb.position, (checkPoints[currentCheckPointIndex].position- rb.transform.position).normalized,distToPoint ,hitLayer);
        
        // if hit, then we update the move direction to follow  a slide direction, which gets the hit point and normalizes the perendicular direction, then using a dot product it evaluates if the slide direction or the inverse are in closer trajectory to the move direction
        if (hit&& hitObjective)
        {
          
            
        
           
           
            Vector2 slideDir = Vector2.Perpendicular(hit.normal).normalized;
            moveDirection = Vector2 . Dot (slideDir , moveDirection) > 0 ? slideDir : -slideDir;
         

        }
        else
        {
            moveDirection = ( checkPoints[currentCheckPointIndex].position- rb.transform.position).normalized;
        }
        
        
        Vector2 moveForce = moveDirection * speed;

      

        if (distToPoint < 0.1)
        {
            UpdateCurrentCheckPoint();
        }
        else
        {
            rb. AddForce (moveForce);
        }
         
       
    }

    void UpdateIdle()
    {
        // if nothing is hit, then move towards the currentclick
        RaycastHit2D hitPlayer = Physics2D.Raycast(rb.position, moveDirection, viewDistance, playerLayer);

        if (hitPlayer)
        {
            SwitchStates(states.Chasing);
        }
        else
        {
            moveDirection = ( checkPoints[currentCheckPointIndex].position - rb.transform.position).normalized;
        }
    }

    void UpdateChasing()
    {
  
        
        if (DEBUGMODE)
        {
            Debug . DrawRay (rb . position , moveDirection * viewDistance , Color . cyan);
        }

        distToPoint = Vector2.Distance(rb.position, checkPoints[currentCheckPointIndex].position);
        // sphere casts to see if any obstacles are hit
        RaycastHit2D hitObjective = Physics2D.Raycast(rb.position, playerTransform.position - rb.transform.position,distToPoint ,hitLayer);
        // sphere casts to see if any obstacles are hit
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, chaseDistance, moveDirection ,0f,hitLayer);
        // if hit, then we update the move direction to follow  a slide direction, which gets the hit point and normalizes the perendicular direction, then using a dot product it evaluates if the slide direction or the inverse are in closer trajectory to the move direction
        if (hit && hitObjective)
        {

            
                Vector2 slideDir = Vector2.Perpendicular(hit.normal).normalized;
                moveDirection = Vector2 . Dot (slideDir , moveDirection) > 0 ? slideDir : -slideDir;
            
            
        }
        else
        {
            moveDirection = ( playerTransform.position- rb.transform.position).normalized;
        }
        
        
        Vector2 moveForce = moveDirection * speed;

        distToPoint = Vector2.Distance(rb.position, playerTransform.position);

        if (distToPoint >= chaseDistance)
        {
            SwitchStates(states.Wandering);
        }

        rb. AddForce (moveForce);
        
         
     
    
    }
    
 
}
