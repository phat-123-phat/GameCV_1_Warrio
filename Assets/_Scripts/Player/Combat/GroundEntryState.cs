using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        // Attack
        attackIndex = settings.groundEntryAttackIndex;
        duration = settings.groundEntryDuration;
        moveDistance = settings.groundEntryMoveDistance; // Gán khoảng cách di chuyển
        moveSpeed = settings.groundEntryMoveSpeed;      // Gán tốc độ di chuyển
        animator.SetTrigger("Attack" + attackIndex);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new GroundComboState());
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}