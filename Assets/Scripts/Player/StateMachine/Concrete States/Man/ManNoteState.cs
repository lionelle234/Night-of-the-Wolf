using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManNoteState : ManState
{
    private float timer;
    public ManNoteState(Man man, ManStateMachine manStateMachine) : base(man, manStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Man.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        timer = 0;
        man.manMator.SetBool("Moving", false);
        man.rb2d.velocity = Vector2.zero;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (timer < 4)
        {
            timer += Time.deltaTime;
        }
        else
        {
            man.dialogue.NoteClose();
            man.StateMachine.ChangeState(man.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
