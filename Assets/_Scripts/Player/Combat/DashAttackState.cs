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
        nameAttack = settings.DashAttackAttackIndex;
        duration = settings.DashAttackDuration;
        moveDistance = settings.DashAttackMoveDistance; 
        moveSpeed = settings.DashAttackMoveSpeed;     
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
