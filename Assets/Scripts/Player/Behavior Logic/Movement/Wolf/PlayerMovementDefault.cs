using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Movement-Default", menuName = "Wolf Logic/Movement Logic/Default")]
public class PlayerMovementDefault : PlayerMovementSOBase
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float driftDur;
    
    public override void DoAnimationTriggerEventLogic(Wolf.AnimationTriggerType triggerType)
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

        //wolf.rb2d.velocity = new Vector2(wolf.movInput.x * speed, wolf.rb2d.velocity.y);
        if (wolf.movInput.x != 0f)
        {
            speed = maxSpeed;
            wolf.rb2d.AddForce(new Vector2(wolf.movInput.x * speed, 0) - wolf.rb2d.velocity, ForceMode2D.Force);
            
        }
        else
        {   
            if (speed > 0)
            {
                speed -= Time.deltaTime * driftDur;    
            }
            else
            {
                wolf.rb2d.velocity = Vector2.zero;
                wolf.StateMachine.ChangeState(wolf.IdleState);
            }


        }
        wolf.currentSpeed = wolf.rb2d.velocity.x;

        if (!wolf.m_facingRight && wolf.movInput.x > 0f)
            Flip();
        else if (wolf.m_facingRight && wolf.movInput.x < 0f)
            Flip();

    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Wolf wolf)
    {
        base.Initialize(gameObject, wolf);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }

    void Flip()
    {
        wolf.m_facingRight = !wolf.m_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
