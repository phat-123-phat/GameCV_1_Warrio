using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class JumpWallMovementState : MovementBaseState
{
  
    private Vector2 wallJumpPower; 
    private float coolDownWallSlide = 0.5f;
    private float _coolDownWallSlide;
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsJumping", true);
        wallJumpPower = settings.wallJumpPower;
        PlayerWallJump();
        _coolDownWallSlide = coolDownWallSlide;
        AudioManager.instance.PlayerSFX("Jump");

    }

    public override void OnUpdate()
    {
       
        base.OnUpdate();
       
        if (_coolDownWallSlide > 0)
        {
            _coolDownWallSlide -= Time.deltaTime;   
        }

        if (isTouchingWall && !isGrounded && _coolDownWallSlide <= 0 )
        {
            stateMachine.SetNextState(new WallSlideMovementState());
            return;
        }


        if (isGrounded && rb.velocity.y < 0)
        {
            stateMachine.SetNextState(new IdleMovementState());
            return;
        }
        if (!isTouchingWall && rb.velocity.y < 0  && _coolDownWallSlide <= 0)
        {
            stateMachine.SetNextState(new FallMovementState());
            return;
        }
        if (Input.GetKeyDown(settings.keyDash) && dashPressedTimer > 0)
        {
            stateMachine.SetNextState(new DashMovementState());
            return;
        }

    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsJumping", false);
    }

    public void PlayerWallJump()
    {
        //rb.transform.localScale = new Vector3(-direction, rb.transform.localScale.y, rb.transform.localScale.z);
        rb.velocity = new Vector2(0 , wallJumpPower.y);
        
        
    }

    
}
