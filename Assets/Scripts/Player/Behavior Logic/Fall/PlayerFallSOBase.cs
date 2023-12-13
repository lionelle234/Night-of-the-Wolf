using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallSOBase : ScriptableObject
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
        wolf.wolfMator.SetTrigger("Falling");
        wolf.canReceiveAttackInput = false;
    }

    public virtual void DoExitLogic() { }

    public virtual void DoFrameUpdateLogic()
    {

        if (wolf.isGrounded)
        {
            wolf.wolfMator.SetTrigger("Grounded");
            wolf.StateMachine.ChangeState(wolf.MovementState);
        }
    }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Wolf.AnimationTriggerType triggerType) { }

    public virtual void ResetValues() { }
}
