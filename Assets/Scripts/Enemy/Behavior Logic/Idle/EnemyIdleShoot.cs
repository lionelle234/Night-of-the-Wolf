using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Shoot", menuName = "Enemy Logic/Idle Logic/Shoot")]
public class EnemyIdleShoot : EnemyIdleSOBase
{
    
    [SerializeField] private float timeBtwShots;
    [SerializeField] private float atkSpeed;
    private Vector2 dir;
    private Rigidbody2D atk;
    private float timer;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {

    }


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        
        timer = 0;
        dir = (enemy.playerTransform.position - enemy.transform.position).normalized;
        Rigidbody2D atk = GameObject.Instantiate(enemy.boneArrow, enemy.transform.position, Quaternion.identity);
        atk.velocity = dir * atkSpeed;

    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();


        dir = (enemy.playerTransform.position - enemy.transform.position).normalized;

        if (timer > timeBtwShots)
        {
            
            timer = 0f;
            if (enemy.playerTransform.position.x > enemy.transform.position.x && enemy.facingRight == false)
            {
                enemy.Flip();
            }
            Rigidbody2D atk = GameObject.Instantiate(enemy.boneArrow, enemy.transform.position, Quaternion.identity);
            atk.velocity = dir * atkSpeed;
            if (atk.velocity.x > 0)
            {
                atk.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            timer += Time.deltaTime;
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
