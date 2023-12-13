using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : WolfState
{
    public PlayerIdleState(Wolf wolf, WolfStateMachine wolfStateMachine) : base(wolf, wolfStateMachine)
    {

    }

    public override void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);

        wolf.PlayerIdleBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        wolf.PlayerIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();

        wolf.PlayerIdleBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        wolf.PlayerIdleBaseInstance.DoFrameUpdateLogic();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        wolf.PlayerIdleBaseInstance.DoPhysicsLogic();
    }


}
