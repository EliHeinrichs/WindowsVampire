using System.Collections;
using System.Collections.Generic;
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
    [Header("Chase Vars")]
    public Transform playerTransform;
    public float chaseDistance;
    
    
    private Vector2[] checkDirs = {Vector2.right, Vector2.up, Vector2.down, Vector2.left };
    

    
    private float nextIndexTimer = 15f;
   
    
    [Header("Idle State Vars")]
    public float idleRandomTime = 5f;
    public float idleRandomRange = 3f;
    private float idleTimer = 10f;



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


    void OnWallDirection()
    {
        Vector2 bestDir = moveDirection;
        float bestDot = -1f;
        foreach (Vector2 potentialDir in checkDirs)
        {
            if (Physics2D.CircleCast(rb.position, viewDistance /2, potentialDir ,viewDistance,hitLayer))
            {
                if (DEBUGMODE)
                {
                    Debug . DrawLine (rb. position , rb.position + potentialDir , Color . red);
                }
            }
            else
            {
                
                if (DEBUGMODE)
                {
                    Debug . DrawLine (rb. position , rb.position + potentialDir , Color . green);
                }
                float dot = Vector2.Dot(potentialDir, moveDirection);
                
                if(dot > bestDot)
                {
                    bestDir = potentialDir;
                    bestDot = dot;
               
                
                }
            }
            
        }
        moveDirection = bestDir;
       
  
        
    }

    void RunCheckPointTimer()
    {
        // if nothing is hit, then move towards the currentclick
        nextIndexTimer -= Time.deltaTime;

        if (nextIndexTimer <= 0)
        {
            nextIndexTimer = 15f;
            UpdateCurrentCheckPoint();
        }
    }

    void UpdateIdle()
    {
        RaycastHit2D hitPlayer = Physics2D.CircleCast(rb.position, chaseDistance, moveDirection ,0f,playerLayer);
        if (hitPlayer)
        {
            SwitchStates(states.Chasing);
        }
        
        idleTimer -= Time.deltaTime;

        if (idleTimer <= 0)
        {
            SwitchStates(states.Wandering);
        }
        
        
        
    }


    void UpdateWandering()
    {
        
       
        RunCheckPointTimer();
            
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

        RaycastHit2D hit = Physics2D.CircleCast(rb.position, viewDistance,moveDirection,0f,hitLayer);
       RaycastHit2D hitObjective = Physics2D.Raycast(rb.position, (checkPoints[currentCheckPointIndex].position- rb.transform.position).normalized,distToPoint ,hitLayer);
        
       
        if (hit && hitObjective )
        {
            OnWallDirection();
        }
        else
        {
            moveDirection = ( checkPoints[currentCheckPointIndex].position- rb.transform.position).normalized;
        }
        
        
        Vector2 moveForce = moveDirection * speed;

      

        if (distToPoint < 1)
        {
            UpdateCurrentCheckPoint();
        }
        else
        {
            rb. AddForce (moveForce);
        }
         
       
    }
    

    void UpdateChasing()
    {
  
        
        RunCheckPointTimer();
        
        if (DEBUGMODE)
        {
            Debug . DrawLine (rb. position , checkPoints[currentCheckPointIndex].position , Color . black);
            Debug . DrawRay (rb . position , moveDirection * viewDistance , Color . cyan);
        }
        
        
        distToPoint = Vector2.Distance(rb.position, playerTransform.position);
        RaycastHit2D hit = Physics2D.CircleCast(rb.position, viewDistance,moveDirection,0f,hitLayer);
        RaycastHit2D hitObjective = Physics2D.Raycast(rb.position, (checkPoints[currentCheckPointIndex].position- rb.transform.position).normalized,distToPoint ,hitLayer);
        
       
        if (hit && hitObjective )
        {
            OnWallDirection();
        }
        else
        {
            moveDirection = ( playerTransform.position- rb.transform.position).normalized;
        }
        
        
        Vector2 moveForce = moveDirection * speed;

        if (playerTransform.gameObject.activeInHierarchy == false)
        {
            idleTimer = Random.Range(idleRandomTime - idleRandomRange , idleRandomTime + idleRandomRange);
            SwitchStates(states.Idle);
            
        }

        
        if (distToPoint >= chaseDistance )
        {
            SwitchStates(states.Wandering);
        }
        else
        {
            rb. AddForce (moveForce);
        }

 
        
         
     
    
    }
 
}
