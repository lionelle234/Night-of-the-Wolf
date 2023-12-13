using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManLedgeState : ManState
{
    public ManLedgeState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        man.manMator.SetTrigger("Ledging");
        man.rb2d.velocity = Vector2.zero;
        man.outOfReach = true;
        
    }

    public override void ExitState()
    {
        base.ExitState();

        
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (man.isLedging == false)
        {
            man.outOfReach = false;
            man.StateMachine.ChangeState(man.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
