using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleSOBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;


    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;

    }

    public virtual void DoEnterLogic()
    {
        enemy.isActive = true;  
    }

    public virtual void DoExitLogic() { }

    public virtual void DoFrameUpdateLogic()
    {

        if (enemy.isActive == false)
        {
            enemy.StateMachine.ChangeState(enemy.InactiveState);
        }
    }

    public virtual void DoPhysicsLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType) { }

    public virtual void ResetValues() { }
}
