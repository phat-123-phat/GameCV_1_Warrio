using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToShootEnemy : EnemyBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsReturnShoot", true);
        duration = Enemysettings.durationReturnShoot;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration )
        {
            if (!isFace2)
            {
                stateMachine.SetNextState(new EnemyFace2State());
            }
            else
            { 
                stateMachine.SetNextState(new IdleEnemyState());
            }
        }

    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsReturnShoot", false);
    }
}
