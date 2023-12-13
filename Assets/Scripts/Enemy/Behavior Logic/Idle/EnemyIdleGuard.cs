using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Guard", menuName = "Enemy Logic/Idle Logic/Guard")]
public class EnemyIdleGuard : EnemyIdleSOBase
{

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {

    }


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        enemy.enemAtor.SetTrigger("Waiting");


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
            if (enemy.hit.collider.gameObject.tag == "Wolf")
            {
                if (enemy.playerTransform.GetComponent<Man>().isHiding == false)
                {
                    enemy.StateMachine.ChangeState(enemy.AggroState);
                }

            }


        }




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
