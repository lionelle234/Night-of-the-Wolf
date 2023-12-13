using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSOBase : ScriptableObject
{
    protected Wolf wolf;
    protected Transform transform;
    protected GameObject gameObject;


    public virtual void Initialize(GameObject gameObject, Wolf wolf)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.wolf = wolf;

    }

    public virtual void DoEnterLogic()
    {
        wolf.canReceiveJumpInput = true;
        wolf.wolfMator.SetBool("Moving", true);
        wolf.canReceiveAttackInput = true;
    }

    public virtual void DoExitLogic() { }

    public virtual void DoFrameUpdateLogic()
    {



        if (wolf.inputReceivedJump)
        {
            wolf.StateMachine.ChangeState(wolf.JumpState);
        }


        if (wolf.rb2d.velocity.y < 0 && wolf.isGrounded == false)
        {
            wolf.StateMachine.ChangeState(wolf.FallState);
        }



    }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Wolf.AnimationTriggerType triggerType) { }

    public virtual void ResetValues() { }
}
