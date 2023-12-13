using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMovementState : ManState
{
    public ManMovementState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }
    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        man.ManMovementBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        man.ManMovementBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        man.ManMovementBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        man.ManMovementBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        man.ManMovementBaseInstance.DoPhysicsLogic();
    }
}
