using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Aggro-Chase", menuName = "Enemy Logic/Aggro Logic/Chase")]
public class EnemyAggroChase : EnemyAggroSOBase
{
    [SerializeField] private float speed;
    [SerializeField] private float count;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {

    }


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();



    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        if (enemy.isActive)
        {
            if (enemy.playerTransform.GetComponent<Man>().outOfReach || enemy.hit.collider == null)
            {
                if (enemy.isActive)
                {
                    enemy.StateMachine.ChangeState(enemy.WaitState);
                }



            }
            else
            {
                if (enemy.playerTransform.position.x < enemy.transform.position.x)
                {

                    enemy.rb2d.velocity = new Vector2(-speed, 0);
                    if (enemy.facingRight)
                    {
                        enemy.Flip();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    enemy.rb2d.velocity = new Vector2(speed, 0);
                    if (enemy.facingRight == false)
                    {
                        enemy.Flip();
                    }
                    else
                    {
                        return;
                    }

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

    }
}
