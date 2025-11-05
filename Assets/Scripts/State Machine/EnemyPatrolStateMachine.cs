using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Action = System.Action;
using UnityEngine;

public class EnemyPatrolStateMachine : StateMachine<EnemyPatrolStateMachine.EnemyState>
{
    public enum EnemyState { North, East, South, West }

    private float currentTimer = 0f;

    [SerializeField]
    private float timeBeforeMove = 1f;

    [SerializeField]
    public Door[] doors;

    [SerializeField]
    public Window[] windows;

    [SerializeField]
    public LightSwitch[] lightSwitches;

    [SerializeField] 
    public GameObject enemyObject;


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

        if (currentTimer >= timeBeforeMove)
        {
            if(!EnterHouseIfOpen())
                ChooseRandomAction();

            currentTimer = 0;
        }
    }

    private bool EnterHouseIfOpen()
    {
        bool returnValue = false;
        if(GetLightSwitchesOnSameSide(true).Length == 0)
        {
            if (GetDoorsOnSameSide(false).Length > 0 || GetWindowsOnSameSide(false).Length > 0)
            {
                Debug.Log("Enemy Has Entered House");
                enemyObject.SetActive(true);
                returnValue = true;
            }
        }
        return returnValue;
    }

    private void ChooseRandomAction()
    {
        List<Action> possibleActions = new List<Action>();
              
        possibleActions.Add(MoveToRandomDirection);

        if (GetDoorsOnSameSide(true).Length > 0)
            possibleActions.Add(ChooseRandomDoorToOpen);

        if (GetWindowsOnSameSide(true).Length > 0)
            possibleActions.Add(ChooseRandomWindowToOpen);

        if (GetLightSwitchesOnSameSide(true).Length > 0)
            possibleActions.Add(ChooseRandomLightswitchToFlick);

        if (possibleActions.Count > 0)
        {
            int random = Random.Range(0, possibleActions.Count);

            possibleActions[random].Invoke();
        }

        else
            Debug.Log("No actions possible");
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
        Door[] doorsToOpen = GetDoorsOnSameSide(true);
              
        if (doorsToOpen.Length > 0)
        {            
            int random = Random.Range(0, doorsToOpen.Length);

            UnlockDoor(doorsToOpen[random]);
        }        
    }

    private void ChooseRandomWindowToOpen()
    {       
        Window[] windowsToOpen = GetWindowsOnSameSide(true);
                  
        if (windowsToOpen.Length > 0)
        {           
            int random = Random.Range(0, windowsToOpen.Length);

            OpenWindow(windowsToOpen[random]);
        }       
    }

    private void ChooseRandomLightswitchToFlick()
    {               
        LightSwitch[] lightSwitchesToFlick = GetLightSwitchesOnSameSide(true);
        
        if (lightSwitchesToFlick.Length > 0)
        {
            int random = Random.Range(0, lightSwitchesToFlick.Length);

            TurnOffLight(lightSwitchesToFlick[random]);
        }       
    }

    private Door[] GetDoorsOnSameSide(bool getActiveDoors)
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

        if(getActiveDoors)
            return doors.Where(doors => doors.side == side && doors.active).ToArray();

        else
            return doors.Where(doors => doors.side == side && !doors.active).ToArray();
    }

    private Window[] GetWindowsOnSameSide(bool getActiveWindows)
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

        if(getActiveWindows)
            return windows.Where(windows => windows.side == side && windows.active).ToArray();

        else
            return windows.Where(windows => windows.side == side && !windows.active).ToArray();
    }

    private LightSwitch[] GetLightSwitchesOnSameSide(bool getActiveSwitches)
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

        if (getActiveSwitches)
            return lightSwitches.Where(lightSwitches => lightSwitches.side == side && lightSwitches.active).ToArray();

        else
            return lightSwitches.Where(lightSwitches => lightSwitches.side == side && !lightSwitches.active).ToArray();
    }

    private void MoveToRandomDirection()
    {
        EnemyState randomState = CurrentState;

        int random = Random.Range(0, 4);

        if (random == 0)
            randomState = EnemyState.North;

        if (random == 1)
            randomState = EnemyState.East;

        if (random == 2)
            randomState = EnemyState.South;

        if (random == 3)
            randomState = EnemyState.West;

        ChangeState(randomState);
    }
}
