using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundComboState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = characterSettings.groundComboAttackIndex;
        duration = characterSettings.groundComboDuration;
        moveDistance = characterSettings.groundComboMoveDistance; // Gán khoảng cách di chuyển
        moveSpeed = characterSettings.groundComboMoveSpeed;      // Gán tốc độ di chuyển
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