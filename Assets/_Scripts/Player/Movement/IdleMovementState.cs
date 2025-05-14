using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class IdleMovementState : MovementBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsIdle", true);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Mathf.Abs(moveInput) > 0 )
        {
            stateMachine.SetNextState(new RunMovementState());
        }

        if (!isGrounded)
        {
            stateMachine.SetNextState(new FallMovementState());
        }

        if (Input.GetKeyDown(settings.keyJump) &&jumpPressedTimer > 0 && isGrounded  )
        {
            stateMachine.SetNextState(new JumpMovementState());
        }
        if (Input.GetKeyDown(settings.keyDash) && dashPressedTimer > 0 )
        {
            stateMachine.SetNextState(new DashMovementState());
        }
        if (!isGrounded && isTouchingWall )
        {
            stateMachine.SetNextState(new WallSlideMovementState());
        }

    }
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsIdle", false);
    }
   
}
