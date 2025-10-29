using System;
using UnityEngine;

public abstract class StateMachine<T> : MonoBehaviour where T : Enum
{
    public T CurrentState { get; private set; }

    private bool isTransitioning = false;

    [SerializeField]
    private bool DEBUG_MODE;

    private void Update()
    {
        OnStateUpdate(CurrentState);
    }

    
    //initializes the state machine with a starting state.   
    protected void Initialize(T startState)
    {
        CurrentState = startState;

        if(DEBUG_MODE)
            Debug.Log("Initialized with state: " + CurrentState);

        OnStateEnter(startState);
    }

    
    // switch to a new state.    
    public void ChangeState(T newState)
    {
        if (isTransitioning || Equals(newState, CurrentState))
            return;

        Transition(newState);
    }

    // transitioning between states
    private void Transition(T newState)
    {
        isTransitioning = true;

        if(DEBUG_MODE)
            Debug.Log("Transitioning from " + CurrentState + " to " + newState);

        // Exit old state
        OnStateExit(CurrentState);    
       
        // Enter new state
        CurrentState = newState;
        OnStateEnter(newState);

        if(DEBUG_MODE)
            Debug.Log("Now in state: " + CurrentState);

        isTransitioning = false;
    }

    // --- methods for subclasses to override ---  
    protected abstract void OnStateEnter(T state);
    protected abstract void OnStateUpdate(T state);
    protected abstract void OnStateExit(T state);
}