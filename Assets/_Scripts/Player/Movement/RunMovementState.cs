using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunMovementState : MovementBaseState
{
    

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsRunning", true);
        
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        

        if (Mathf.Abs(moveInput) == 0)
        {
            stateMachine.SetNextState(new IdleMovementState());
        }

        if (Input.GetKeyDown(characterSettings.keyJump) && isGrounded )
        {
            stateMachine.SetNextState(new JumpMovementState());

           
        }
        if (Input.GetKeyDown(characterSettings.keyDash) && dashPressedTimer > 0)
        {
            stateMachine.SetNextState(new DashMovementState());
        }

        if (isTouchingWall && !isGrounded )
        {
            stateMachine.SetNextState(new WallSlideMovementState());
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsRunning", false);
    }
    
}
