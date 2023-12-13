using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : WolfState
{
    public PlayerMovementState(Wolf wolf, WolfStateMachine wolfStateMachine) : base(wolf, wolfStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        wolf.PlayerMovementBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        wolf.PlayerMovementBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        wolf.PlayerMovementBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        wolf.PlayerMovementBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        wolf.PlayerMovementBaseInstance.DoPhysicsLogic();
    }
}
