using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpSOBase : ScriptableObject
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
        wolf.canReceiveJumpInput = false;
        wolf.wolfMator.SetBool("Moving", false);
        wolf.wolfMator.SetTrigger("Jumping");
        wolf.inputReceivedJump = false;
        wolf.canReceiveAttackInput = false;
        wolf.voice.PlaySFX(0);
    }

    public virtual void DoExitLogic() { }

    public virtual void DoFrameUpdateLogic()
    {

        if (wolf.rb2d.velocity.y < 0f)
        {
            wolf.StateMachine.ChangeState(wolf.FallState);
        }
    }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Wolf.AnimationTriggerType triggerType) { }

    public virtual void ResetValues() { }
}
