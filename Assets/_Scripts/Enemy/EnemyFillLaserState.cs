using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFillLaserState : EnemyBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsFillLaser", true);
        duration = Enemysettings.durationFillMana;

    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration)
        {

            stateMachine.SetNextState(new ReturnToShootEnemy());
        }

        if (EnemyHealth.currentHealth <= EnemyHealth.maxHealth / 2 && !isFace2)
        {

            stateMachine.SetNextState(new ReturnToShootEnemy());

        }
    }
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsFillLaser", false);
    }
}
