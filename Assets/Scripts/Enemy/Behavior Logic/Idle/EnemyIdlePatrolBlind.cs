using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-PatrolBlind", menuName = "Enemy Logic/Idle Logic/Blind")]
public class EnemyIdlePatrolBlind : EnemyIdleSOBase
{
    [SerializeField] private float count;
    [SerializeField] private float speed;
    private float maxSpeed;
    private float timer;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {

    }


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        timer = 0;
        maxSpeed = speed;

        if (enemy.facingRight)
        {
            maxSpeed *= 1;
        }
        else
        {
            maxSpeed *= -1;
        }



    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

        timer = 0;

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();


        if (timer < count)
        {
            timer += Time.deltaTime;

        }
        else
        {
            maxSpeed *= -1;
            enemy.Flip();
            timer = 0;
        }
        enemy.rb2d.velocity = new Vector2(maxSpeed, 0);


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
