using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyStunState : EnemyState
{
    private float count = 4f;
    private float timer;
    public EnemyStunState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
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
        enemy.isStunned = true;
        enemy.rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        enemy.rb2d.velocity = Vector2.zero;
        enemy.voice.PlaySFX(0);
        timer = 0;
    }

    public override void ExitState()
    {
        base.ExitState();

        enemy.isStunned = false;    
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (timer < count)
        {
            timer += Time.deltaTime;
        }
        else
        {
            enemy.rb2d.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            enemy.enemAtor.SetTrigger("Idling");
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }

        if (enemy.isActive == false)
        {
            enemy.StateMachine.ChangeState(enemy.InactiveState);
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
