using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisplay : AbstractObject
{  
    public EnemyPatrolStateMachine enemyStateMachine;

    private void GetAndDisplayEnemyPosition()
    {
        switch (enemyStateMachine.CurrentState)
        {
            case EnemyPatrolStateMachine.EnemyState.North:
                if (side == Side.North && !active)                   
                    ToggleActive();
                break;
            case EnemyPatrolStateMachine.EnemyState.East:
                if (side == Side.East && !active)
                    ToggleActive();
                break;
            case EnemyPatrolStateMachine.EnemyState.South:
                if (side == Side.South && !active)
                    ToggleActive();
                break;
            case EnemyPatrolStateMachine.EnemyState.West:
                if (side == Side.West && !active)
                    ToggleActive();
                break;
        }
        
        switch (side)
        {
            case Side.North:
                if (enemyStateMachine.CurrentState != EnemyPatrolStateMachine.EnemyState.North && active)
                    ToggleActive();
                break;
            case Side.East:
                if (enemyStateMachine.CurrentState != EnemyPatrolStateMachine.EnemyState.East && active)
                    ToggleActive();              
                break;
            case Side.South:
                if (enemyStateMachine.CurrentState != EnemyPatrolStateMachine.EnemyState.South && active)
                    ToggleActive();             
                break;
            case Side.West:
                if (enemyStateMachine.CurrentState != EnemyPatrolStateMachine.EnemyState.West && active)
                    ToggleActive();
                break;
        }
    }
    private void Update()
    {
        if (active)
            spriteRenderer.color = Color.blue;
        else 
            spriteRenderer.color = Color.black;
        GetAndDisplayEnemyPosition();
    }
}
