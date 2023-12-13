using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManIdleSOBase : ScriptableObject
{
    protected Man man;
    protected Transform transform;
    protected GameObject gameObject;


    public virtual void Initialize(GameObject gameObject, Man man)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.man = man;

    }

    public virtual void DoEnterLogic()
    {
        
        man.manMator.SetBool("Moving", false);
        man.canReceiveTorchInput = true;
    }

    public virtual void DoExitLogic() { }

    public virtual void DoFrameUpdateLogic()
    {


        if (man.movInput.x != 0 && man.isGrounded)
        {
            man.StateMachine.ChangeState(man.MovementState);
        }

        if (man.movInput.y > 0 && man.isLaddered)
        {
            man.StateMachine.ChangeState(man.LadderState);
        }

        if (man.inputReceivedTorch)
        {
            man.StateMachine.ChangeState(man.TorchState);
        }

        if (man.rb2d.velocity.y < 0 && man.isGrounded == false)
        {
            man.StateMachine.ChangeState(man.FallState);
        }





    }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Man.AnimationTriggerType triggerType) { }

    public virtual void ResetValues() { }
}
