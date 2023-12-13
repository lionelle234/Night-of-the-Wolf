using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManIdleState : ManState
{
    public ManIdleState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        man.ManIdleBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        man.ManIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        man.ManIdleBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        man.ManIdleBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        man.ManIdleBaseInstance.DoPhysicsLogic();
    }
}
