using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-PatrolGround", menuName = "Enemy Logic/Idle Logic/PatrolGround")]

public class EnemyIdlePatrolGround : EnemyIdleSOBase
{

    [SerializeField] private float speed;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {

    }


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();


        enemy.maxSpeed = speed;

        if (enemy.facingRight)
        {
            enemy.maxSpeed *= 1;
        }
        else
        {
            enemy.maxSpeed *= -1;
        }
        


    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        if (enemy.hit.collider != null)
        {
            if (enemy.hit.collider.gameObject.tag == "Player")
            {   
                if (enemy.playerTransform.GetComponent<Man>().isHiding == false)
                {
                    enemy.StateMachine.ChangeState(enemy.AggroState);
                }
                
            }
            

        }


        enemy.rb2d.velocity = new Vector2(enemy.maxSpeed, 0);


    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
