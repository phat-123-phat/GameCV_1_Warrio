using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideMovementState : MovementBaseState
{
    protected float wallSlideSpeed = -1f;
   
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsWallSliding", true);
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        PlayerWallSliding();

        if (isGrounded && rb.velocity.y < 0 )
        {
            stateMachine.SetNextState(new IdleMovementState());
        }
        if (!isTouchingWall && rb.velocity.y < 0)
        {
            stateMachine.SetNextState(new FallMovementState());
        }
        if (Input.GetKeyDown(settings.keyJump) && !isGrounded && isTouchingWall )
        {
            stateMachine.SetNextState(new JumpWallMovementState());
        }
     
    }
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsWallSliding", false);
    }

    public void PlayerWallSliding()
    {
        rb.velocity = new Vector2(rb.velocity.x, wallSlideSpeed);
    }
   
}
