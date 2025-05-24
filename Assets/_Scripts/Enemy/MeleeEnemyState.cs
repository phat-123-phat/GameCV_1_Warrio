using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MeleeEnemyState : EnemyBaseState
{
    
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsMelee", true);
        duration = Enemysettings.durationMelee;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration)
        {
            float distanceToPlayer = DistanceToPlayer();
            if (distanceToPlayer < attackRange)
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
        animator.SetBool("IsMelee", false);
    }
}
