using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossState
{
    private float timer;
    private float timer2;
    public BossAttackState(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Boss.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
        timer2 = 0;
        boss.rb2d.velocity = Vector2.zero;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (timer < 0.1f)
        {
            timer += Time.deltaTime;
        }
        else
        {   
            if (boss.isActive)
            {
                if (boss.hitGround == false)
                {
                    boss.bossmAtor.SetBool("AttackingB", true);
                    boss.rb2d.velocity = new Vector2(0, -1.3f);
                }
                else
                {
                    boss.bossmAtor.SetBool("AttackingB", false);
                    boss.rb2d.velocity = Vector2.zero;

                    if (timer2 < boss.waitCount)
                    {
                        timer2 += Time.deltaTime;
                    }
                    else
                    {
                        boss.StateMachine.ChangeState(boss.TeleportState);
                    }
                }
            }
            else
            {
                boss.bossmAtor.SetBool("AttackingB", false);
                boss.StateMachine.ChangeState(boss.InactiveState);
            }

        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
