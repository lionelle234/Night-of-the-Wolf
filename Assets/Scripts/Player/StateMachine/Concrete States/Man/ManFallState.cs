using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManFallState : ManState
{
    public ManFallState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        man.manMator.SetTrigger("Falling");
    }

    public override void ExitState()
    {
        base.ExitState();

        
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        man.rb2d.velocity = new Vector2(0, man.rb2d.velocity.y) + Vector2.up * Physics2D.gravity.y * (0.2f - 1) * Time.fixedDeltaTime;

        if (man.isGrounded)
        {
            man.rb2d.velocity = Vector2.zero;
            man.manMator.SetTrigger("Landing");
            man.StateMachine.ChangeState(man.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
