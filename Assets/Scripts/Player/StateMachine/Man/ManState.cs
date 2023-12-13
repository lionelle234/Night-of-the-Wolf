using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManState
{
    protected Man man;
    protected ManStateMachine manStateMachine;

    public ManState(Man man, ManStateMachine manStateMachine)
    {
        this.man = man;
        this.manStateMachine = manStateMachine;
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

    public virtual void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {

    }
}
