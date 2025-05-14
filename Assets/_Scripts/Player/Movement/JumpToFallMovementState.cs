using UnityEngine;

public class JumpToFallMovementState : MovementBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsFalling", true);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (isGrounded)
        {
            stateMachine.SetNextState(new IdleMovementState());
        }
        if (Input.GetKeyDown(settings.keyDash) && dashPressedTimer > 0)
        {
            stateMachine.SetNextState(new DashMovementState());

        }
        if (isTouchingWall && !isGrounded)
        {
            stateMachine.SetNextState(new WallSlideMovementState());
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsFalling", false);
    }
}