using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : WolfState
{
    public PlayerAttackState(Wolf wolf, WolfStateMachine wolfStateMachine) : base(wolf, wolfStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        wolf.wolfMator.SetTrigger("Attacking");
        wolf.canReceiveAttackInput = false;
        wolf.canReceiveJumpInput = false;
        wolf.voice.PlaySFX(1);

    }

    public override void ExitState()
    {
        base.ExitState();
        if (wolf.movInput.x == 0)
        {
            wolf.currentSpeed = 0;
        }

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (wolf.rb2d.velocity.x != 0)
        {
            if (wolf.movInput.x != 0)
            {
                wolf.rb2d.velocity = new Vector2(wolf.currentSpeed, wolf.rb2d.velocityY);
            }
            else
            {
                wolf.rb2d.velocity = Vector2.zero;
            }
        }



    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
