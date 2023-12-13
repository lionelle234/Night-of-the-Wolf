using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : WolfState
{
    public PlayerFallState(Wolf wolf, WolfStateMachine wolfStateMachine) : base(wolf, wolfStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        wolf.PlayerFallBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        wolf.PlayerFallBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        wolf.PlayerFallBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        wolf.PlayerFallBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        wolf.PlayerFallBaseInstance.DoPhysicsLogic();
    }
}
