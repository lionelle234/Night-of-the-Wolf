using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossState
{

    private Vector2 dir;
    private Rigidbody2D atk;
    private float timer;
    private float timerChange;
    private int random;
    public BossIdleState(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine)
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
        timerChange = 0;
        boss.isVulnerable = true;

        if (boss.spr.color == Color.red)
        {
            boss.spr.color = Color.white;
        }
        random = Random.Range(boss.random1, boss.random2);



    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        dir = (boss.playerTransform.position - boss.transform.position).normalized;

        if (timer > boss.timeBtwShots)
        {

            timer = 0f;
            Rigidbody2D atk = GameObject.Instantiate(boss.projecTile, boss.transform.position, Quaternion.identity);
            atk.velocity = dir * boss.atkSpeed;

        }
        else
        {
            timer += Time.deltaTime;
        }
        if (timerChange < random)
        {
            timerChange += Time.deltaTime;
            boss.rb2d.velocity = new Vector2(boss.maxSpeed, 0);
        }
        else
        {
            boss.StateMachine.ChangeState(boss.AttackState);
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
