using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManDeadState : ManState
{
    public ManDeadState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        man.manMator.SetTrigger("Dying");
        man.rb2d.velocity = Vector2.zero;
        man.rb2d.gravityScale = 0;
        man.bc2d.enabled = false;
        man.objChildren.SetActive(false);
        DirectorController.instance.GameOver();
       
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
