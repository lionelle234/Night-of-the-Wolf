using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : WolfState
{
    public PlayerDeadState(Wolf wolf, WolfStateMachine wolfStateMachine) : base(wolf, wolfStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        wolf.wolfMator.SetTrigger("Dying");
        wolf.canReceiveAttackInput = false;
        wolf.canReceiveHoldInput = false;
        wolf.canReceiveJumpInput = false;
        wolf.rb2d.velocity = Vector2.zero;
        wolf.rb2d.gravityScale = 0;
        wolf.bc2d.enabled = false;
        wolf.objChildren.SetActive(false);
        wolf.inventory.ChangeHearts(3);
        wolf.ReleaseObject();
        DirectorController.instance.GameOverWolf();
    }

    public override void ExitState()
    {
        base.ExitState();

        wolf.inventory.ResetHearts();
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
