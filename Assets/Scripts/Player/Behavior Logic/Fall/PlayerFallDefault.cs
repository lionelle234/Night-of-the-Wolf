using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fall-Default", menuName = "Wolf Logic/Fall Logic/Default")]
public class PlayerFallDefault : PlayerFallSOBase
{
    [SerializeField] private float fallMultiplier;
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

        wolf.rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;



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
}
