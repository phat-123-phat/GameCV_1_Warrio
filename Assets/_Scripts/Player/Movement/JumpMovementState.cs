using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovementState : MovementBaseState
{
    private float jumpForce;
   
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsJumping", true);
        jumpForce = settings.jumpForce;
        PlayerJump();
        AudioManager.instance.PlayerSFX("Jump");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (isGrounded && rb.velocity.y <= 0f)
        {
            stateMachine.SetNextState(new IdleMovementState());
            return;
        }

        if (rb.velocity.y < 0f)
        {
            stateMachine.SetNextState(new JumpToFallMovementState());
            return;
        }
        if (Input.GetKeyDown(settings.keyDash) && dashPressedTimer > 0)
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
        animator.SetBool("IsJumping", false);
    }
    public void PlayerJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    
}
