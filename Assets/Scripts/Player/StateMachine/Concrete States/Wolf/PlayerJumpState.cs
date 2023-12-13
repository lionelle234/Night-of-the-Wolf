using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : WolfState
{
    public PlayerJumpState(Wolf wolf, WolfStateMachine wolfStateMachine) : base(wolf, wolfStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        wolf.PlayerJumpBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        wolf.PlayerJumpBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        wolf.PlayerJumpBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        wolf.PlayerJumpBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        wolf.PlayerJumpBaseInstance.DoPhysicsLogic();
    }


}
