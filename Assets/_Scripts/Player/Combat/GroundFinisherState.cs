using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFinisherState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = settings.groundFinisherAttackIndex;
        duration = settings.groundFinisherDuration;
        moveDistance = settings.groundFinisherMoveDistance; // Gán khoảng cách di chuyển
        moveSpeed = settings.groundFinisherMoveSpeed;      // Gán tốc độ di chuyển
        animator.SetTrigger("Attack" + attackIndex);
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