using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemyState : EnemyBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsIdle", true);
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        float distanceToPlayer = DistanceToPlayer();
        if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer <= attackRange)
            {
                stateMachine.SetNextState(new MeleeEnemyState());
            }
            else
            {
                stateMachine.SetNextState(new PrepareToShootEnemyState());
            }
        }

    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsIdle", false);
    }
}
