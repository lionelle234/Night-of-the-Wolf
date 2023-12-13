using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManDropState : ManState
{
    public ManDropState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        if (man.m_facingRight)
        {
            man.m_facingRight = false;
        }
        else
        {
            man.m_facingRight = true;
        }
        man.rb2d.gravityScale = 0;
        man.canReceiveTorchInput = false;
        man.manMator.SetTrigger("Dropping");
        man.rb2d.velocity = Vector2.zero;
        man.outOfReach = true;
    }

    public override void ExitState()
    {
        base.ExitState();
        man.m_facingRight = !man.m_facingRight;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
