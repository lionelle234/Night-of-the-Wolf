using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyInactiveState : EnemyState
{
    public EnemyInactiveState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        enemy.transform.position = enemy.iniPos;
        if (enemy.facingRight != enemy.iniFacing)
        {
            enemy.Flip();
        }
        enemy.rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.isActive = true;
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
