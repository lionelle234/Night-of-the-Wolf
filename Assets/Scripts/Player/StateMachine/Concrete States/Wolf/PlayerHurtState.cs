using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : WolfState
{
    private float timer;
    public PlayerHurtState(Wolf wolf, WolfStateMachine wolfStateMachine) : base(wolf, wolfStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Wolf.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        timer = 0;
        wolf.wolfMator.SetTrigger("Hurting");
        wolf.rb2d.velocity = Vector2.zero;
        wolf.isVulnerable = false;
        wolf.canReceiveAttackInput = false;
        wolf.canReceiveJumpInput = false;
        wolf.canReceiveHoldInput = false;
        wolf.voice.PlaySFX(2);
    }

    public override void ExitState()
    {
        base.ExitState();

        wolf.isVulnerable = true;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (timer < 0.2f)
        {
            timer += Time.deltaTime;
        }
        else
        {   
            if (wolf.rb2d.velocity.y >= 0)
            {
                wolf.wolfMator.SetTrigger("Idling");
                wolf.StateMachine.ChangeState(wolf.IdleState);
            }
            else
            {
                wolf.wolfMator.SetTrigger("Falling");
                wolf.StateMachine.ChangeState(wolf.FallState);
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
