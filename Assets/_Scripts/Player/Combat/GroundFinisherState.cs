using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFinisherState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = characterSettings.groundFinisherAttackIndex;
        duration = characterSettings.groundFinisherDuration;
        moveDistance = characterSettings.groundFinisherMoveDistance; // Gán khoảng cách di chuyển
        moveSpeed = characterSettings.groundFinisherMoveSpeed;      // Gán tốc độ di chuyển
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