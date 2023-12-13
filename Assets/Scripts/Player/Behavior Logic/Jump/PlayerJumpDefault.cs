using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Jump-Default", menuName = "Wolf Logic/Jump Logic/Default")]
public class PlayerJumpDefault : PlayerJumpSOBase
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float airSpeed;
    public override void DoAnimationTriggerEventLogic(Wolf.AnimationTriggerType triggerType)
    {

    }


    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        wolf.inputReceivedJump = false;
        wolf.rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);



    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();


        wolf.rb2d.velocity = new Vector2(wolf.currentSpeed * airSpeed * 1, wolf.rb2d.velocityY);






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
