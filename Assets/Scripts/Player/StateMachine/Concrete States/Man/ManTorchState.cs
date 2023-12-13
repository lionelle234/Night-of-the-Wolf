using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManTorchState : ManState
{
    public ManTorchState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        man.canReceiveTorchInput = false;
        man.inputReceivedTorch = false;
        man.manMator.SetTrigger("Torching");
        man.manMator.SetBool("Moving", false);
        man.rb2d.velocity = Vector2.zero;
    }

    public override void ExitState()
    {
        base.ExitState();
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
