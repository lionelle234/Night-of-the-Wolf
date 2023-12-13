using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandingState : EnemyState
{
    private float timer;

    public EnemyStandingState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        enemy.enemAtor.SetTrigger("Idling");
        enemy.rb2d.velocity = Vector2.zero;
        timer = 0;
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (timer < 2)
        {
            timer += Time.deltaTime;

        }
        else
        {   
            enemy.transform.position = enemy.iniPos;
            enemy.spr.color = Color.white;
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    
}
