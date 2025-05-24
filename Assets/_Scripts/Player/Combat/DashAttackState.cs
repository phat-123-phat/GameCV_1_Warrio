using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DashAttackState : MeleeBaseState
{
    protected string nameAttack;
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        nameAttack = characterSettings.DashAttackAttackIndex;
        duration = characterSettings.DashAttackDuration;
        moveDistance = characterSettings.DashAttackMoveDistance; 
        moveSpeed = characterSettings.DashAttackMoveSpeed;     
        animator.SetTrigger("Attack" + nameAttack);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            stateMachine.SetNextStateToMain();
        }
    }
}
