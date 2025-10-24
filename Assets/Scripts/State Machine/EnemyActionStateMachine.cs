using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionStateMachine : StateMachine<EnemyActionStateMachine.EnemyAction>
{
    public enum EnemyAction {UnlockDoor, OpenWindow, TurnOffLight}

    
    protected override void OnStateEnter(EnemyAction state)
    {
        switch (state)
        {
            case EnemyAction.UnlockDoor:

                break;
            case EnemyAction.OpenWindow:

                break;
            case EnemyAction.TurnOffLight:

                break;          
        }
    }

    protected override void OnStateUpdate(EnemyAction state)
    {        
        switch (state)
        {
            case EnemyAction.UnlockDoor:
                
                break;
            case EnemyAction.OpenWindow:
                
                break;
            case EnemyAction.TurnOffLight:
                
                break;
            
        }
    }

    protected override void OnStateExit(EnemyAction state)
    {

    }
}
