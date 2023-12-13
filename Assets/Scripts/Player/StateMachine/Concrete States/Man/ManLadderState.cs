using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManLadderState : ManState
{
    private float climbSpeed = 0.15f;
    public ManLadderState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        man.manMator.SetBool("Moving", false);
        man.manMator.SetTrigger("Laddering");
        man.canReceiveTorchInput = false;
        man.rb2d.gravityScale = 0;
        man.outOfReach = true;

    }

    public override void ExitState()
    {
        base.ExitState();

        
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        
        man.rb2d.velocity = new Vector2(0, man.movInput.y * climbSpeed);

        if (man.isGrounded && man.movInput.y < 0)
        {
            man.outOfReach = false;
            man.manMator.SetTrigger("Grounded");
            man.rb2d.gravityScale = 1;
            man.StateMachine.ChangeState(man.IdleState);
        }

        if (man.movInput.y != 0)
        {
            man.manMator.SetBool("Climbing", true);
        }
        else
        {
            man.manMator.SetBool("Climbing", false);
        }

        if (man.isLedging)
        {   
            man.StateMachine.ChangeState(man.LedgeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
