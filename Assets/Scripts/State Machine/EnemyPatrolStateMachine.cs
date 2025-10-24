using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolStateMachine : StateMachine<EnemyPatrolStateMachine.EnemyState>
{
    public EnemyActionStateMachine actionStateMachine;
    public enum EnemyState {North, East, South, West }

    private float currentTimer = 0f;

    private float timeBeforeMove = 1f;

    private void Start()
    {
        Initialize(EnemyState.North);
    }

    protected override void OnStateEnter(EnemyState state)
    {      
        switch (state)
        {
            case EnemyState.North:
                
                break;
            case EnemyState.East:
                
                break;
            case EnemyState.South:
                
                break;
            case EnemyState.West:
                
                break;
        }
    }

    protected override void OnStateUpdate(EnemyState state)
    {
        UpdateTimer();

        switch (state)
        {
            case EnemyState.North:
                
                break;
            case EnemyState.East:
                
                break;
            case EnemyState.South:
                
                break;
            case EnemyState.West:
                
                break;
        }
    }

    protected override void OnStateExit(EnemyState state)
    {
        
    }

    private void UpdateTimer()
    {
        currentTimer += Time.deltaTime;

        if(currentTimer >= timeBeforeMove)
        {
            ChangeState(MoveToRandomDirection(CurrentState));
            currentTimer = 0;
        }
    }

    private EnemyState MoveToRandomDirection(EnemyState currentState)
    {
        EnemyState randomState = currentState;
        int random = Random.Range(0, 3);

        if(random == 0)
            randomState = EnemyState.North;
        
        if(random == 1)
            randomState = EnemyState.East;

        if(random == 2)
            randomState = EnemyState.South;

        if(random == 3)
            randomState = EnemyState.West;
      
        return randomState;
    }
}
