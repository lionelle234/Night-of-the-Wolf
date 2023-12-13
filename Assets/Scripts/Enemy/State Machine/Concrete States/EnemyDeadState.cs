using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyDeadState : EnemyState
{
    private float timer;
    public EnemyDeadState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.enemAtor.SetTrigger("Stunning");
        enemy.rb2d.velocity = Vector2.zero;
        enemy.bc2d.enabled = false;
        enemy.voice.PlaySFX(0);
        timer = 0;
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (timer < 0.3f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            enemy.Dead();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
