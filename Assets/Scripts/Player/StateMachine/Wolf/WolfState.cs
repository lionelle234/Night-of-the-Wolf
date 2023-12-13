using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfState
{
    protected Wolf wolf;
    protected WolfStateMachine wolfStateMachine;

    public WolfState(Wolf wolf, WolfStateMachine wolfStateMachine)
    {
        this.wolf = wolf;
        this.wolfStateMachine = wolfStateMachine;
    }

    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

    public virtual void FrameUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {

    }
}
