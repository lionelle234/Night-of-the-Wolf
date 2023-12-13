using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement-Default", menuName = "Man Logic/Movement Logic/Default")]
public class ManMovementDefault : ManMovementSOBase
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float driftDur;

    public override void DoAnimationTriggerEventLogic(Man.AnimationTriggerType triggerType)
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

        if (man.movInput.x != 0f)
        {
            speed = maxSpeed;
            man.rb2d.AddForce(new Vector2(man.movInput.x * speed, 0) - man.rb2d.velocity, ForceMode2D.Force);

        }
        else
        {
            if (speed > 0)
            {
                speed -= Time.deltaTime * driftDur;
            }
            else
            {
                man.rb2d.velocity = Vector2.zero;
                man.StateMachine.ChangeState(man.IdleState);
            }

        }
        man.currentSpeed = man.rb2d.velocity.x;

        if (!man.m_facingRight && man.movInput.x > 0f)
            Flip();
        else if (man.m_facingRight && man.movInput.x < 0f)
            Flip();

    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Man man)
    {
        base.Initialize(gameObject, man);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }

    void Flip()
    {
        man.m_facingRight = !man.m_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
