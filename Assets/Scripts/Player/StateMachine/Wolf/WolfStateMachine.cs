using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfStateMachine
{
    public WolfState CurrentWolfState { get; set; }

    public void Initialize(WolfState startingState)
    {
        CurrentWolfState = startingState;
        CurrentWolfState.EnterState();
    }

    public void ChangeState(WolfState newState)
    {
        CurrentWolfState.ExitState();
        CurrentWolfState = newState;
        CurrentWolfState.EnterState();
    }
}
