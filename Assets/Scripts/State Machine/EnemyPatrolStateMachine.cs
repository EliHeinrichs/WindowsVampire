using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrolStateMachine : StateMachine<EnemyPatrolStateMachine.EnemyState>
{   
    public enum EnemyState {North, East, South, West }

    private float currentTimer = 0f;

    private float timeBeforeMove = 1f;

    public Door[] doors;

    public Window[] windows;

    public LightSwitch[] lightSwitches;

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
            ChooseRandomAction();
            currentTimer = 0;
        }
    }

    private void ChooseRandomAction()
    {
        int random = Random.Range(0, 4);

        if (random == 0)
            MoveToRandomDirection();

        if (random == 1)              
            ChooseRandomDoorToOpen();
        
        if (random == 2)
            ChooseRandomWindowToOpen();
        
        if (random == 3)
            ChooseRandomLightswitchToFlick();
        
    }
    private void UnlockDoor(Door doorToOpen)
    {
        doorToOpen.ToggleActive();
    }

    private void OpenWindow(Window windowToOpen)
    {
        windowToOpen.ToggleActive();
    }

    private void TurnOffLight(LightSwitch lightSwitchToFlick)
    {
        lightSwitchToFlick.ToggleActive();
    }

    private void ChooseRandomDoorToOpen()
    {
        Door[] doorsToOpen = GetDoorsOnSameSide();
        int random = Random.Range(0, doorsToOpen.Length);

        UnlockDoor(doorsToOpen[random]);
    }

    private void ChooseRandomWindowToOpen()
    {
        Window[] windowsToOpen = GetWindowsOnSameSide();
        int random = Random.Range(0, windowsToOpen.Length);

        OpenWindow(windowsToOpen[random]);
    }

    private void ChooseRandomLightswitchToFlick()
    {
        LightSwitch[] lightSwitchesToFlick = GetLightSwitchesOnSameSide();
        int random = Random.Range(0, lightSwitchesToFlick.Length);

        TurnOffLight(lightSwitchesToFlick[random]);
    }

    private Door[] GetDoorsOnSameSide()
    {
        AbstractObject.Side side = AbstractObject.Side.North;

        switch (CurrentState)
        {
            case EnemyState.North:
                side = AbstractObject.Side.North;
                break;
            case EnemyState.East:
                side = AbstractObject.Side.East;
                break;
            case EnemyState.South:
                side = AbstractObject.Side.South;
                break;
            case EnemyState.West:
                side = AbstractObject.Side.West;
                break;
        }

        return doors.Where(doors => doors.side == side).ToArray();
    }

    private Window[] GetWindowsOnSameSide()
    {
        AbstractObject.Side side = AbstractObject.Side.North;

        switch (CurrentState)
        {
            case EnemyState.North:
                side = AbstractObject.Side.North;
                break;
            case EnemyState.East:
                side = AbstractObject.Side.East;
                break;
            case EnemyState.South:
                side = AbstractObject.Side.South;
                break;
            case EnemyState.West:
                side = AbstractObject.Side.West;
                break;
        }

        return windows.Where(windows => windows.side == side).ToArray();
    }

    private LightSwitch[] GetLightSwitchesOnSameSide()
    {
        AbstractObject.Side side = AbstractObject.Side.North;

        switch (CurrentState)
        {
            case EnemyState.North:
                side = AbstractObject.Side.North;
                break;
            case EnemyState.East:
                side = AbstractObject.Side.East;
                break;
            case EnemyState.South:
                side = AbstractObject.Side.South;
                break;
            case EnemyState.West:
                side = AbstractObject.Side.West;
                break;
        }

        return lightSwitches.Where(lightSwitches => lightSwitches.side == side).ToArray();
    }

    private void MoveToRandomDirection()
    {
        EnemyState randomState = CurrentState;

        int random = Random.Range(0, 4);

        if(random == 0)
            randomState = EnemyState.North;
        
        if(random == 1)
            randomState = EnemyState.East;

        if(random == 2)
            randomState = EnemyState.South;

        if(random == 3)
            randomState = EnemyState.West;
      
        ChangeState(randomState);
    }
}
