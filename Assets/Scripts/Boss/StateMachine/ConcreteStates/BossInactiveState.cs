using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInactiveState : BossState
{
    public BossInactiveState(Boss boss, BossStateMachine bossStateMachine) : base(boss, bossStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        
        boss.rb2d.velocity = Vector2.zero;

        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
