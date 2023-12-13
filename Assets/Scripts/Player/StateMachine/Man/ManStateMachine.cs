using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManStateMachine
{
    public ManState CurrentManState { get; set; }

    public void Initialize(ManState startingState)
    {
        CurrentManState = startingState;
        CurrentManState.EnterState();
    }

    public void ChangeState(ManState newState)
    {
        CurrentManState.ExitState();
        CurrentManState = newState;
        CurrentManState.EnterState();
    }
}
