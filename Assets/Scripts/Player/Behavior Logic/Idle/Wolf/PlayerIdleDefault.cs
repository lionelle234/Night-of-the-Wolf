using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Default", menuName = "Wolf Logic/Idle Logic/Default")]
public class PlayerIdleDefault : PlayerIdleSOBase
{

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