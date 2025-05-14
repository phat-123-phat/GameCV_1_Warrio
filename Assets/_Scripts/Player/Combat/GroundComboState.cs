using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundComboState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = settings.groundComboAttackIndex;
        duration = settings.groundComboDuration;
        moveDistance = settings.groundComboMoveDistance; // Gán khoảng cách di chuyển
        moveSpeed = settings.groundComboMoveSpeed;      // Gán tốc độ di chuyển
        animator.SetTrigger("Attack" + attackIndex);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new GroundFinisherState());
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}