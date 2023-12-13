using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaitState : EnemyState
{
    public EnemyWaitState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        enemy.enemAtor.SetTrigger("Waiting");
        enemy.rb2d.velocity = Vector2.zero;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();


        if (enemy.hit.collider != null)
        {
            if (enemy.hit.collider.gameObject.tag == "Wolf")
            {
                if (enemy.playerTransform.GetComponent<Man>().isHiding == false)
                {
                    enemy.StateMachine.ChangeState(enemy.AggroState);
                }

            }


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
