using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovementState : MovementBaseState
{
    protected float dashSpeed;
    protected float dashDistance;
    private float distanceMoved;
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsDashing", true);
        dashSpeed = characterSettings.dashSpeed;
        dashDistance = characterSettings.dashDistance;
        duration = characterSettings.dashDuration;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!IsAttacking())
        {
            PlayerDash();
        }
        
        if (fixedtime >= duration)
        {
            if (isGrounded && rb.velocity.y <= 0f)
            {
                stateMachine.SetNextState(new IdleMovementState());
                return;
            }

            if (rb.velocity.y < 0f && !isTouchingWall)
            {
                stateMachine.SetNextState(new JumpToFallMovementState());
                return;
            }
            
        }
        if (Input.GetKeyDown(characterSettings.keyAtk))
        {
            duration = 0;
        }
        if (isTouchingWall && !isGrounded )
        {
            stateMachine.SetNextState(new WallSlideMovementState());
            duration = 0;
        }

        

    }
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsDashing", false);
        if (rb != null)
            rb.velocity = new Vector2(0f, rb.velocity.y);
    }
    protected void PlayerDash()
    {
        if (rb == null || distanceMoved >= dashDistance)
            return;

        // Xác định hướng di chuyển dựa trên localScale.x (hướng nhân vật đang đối mặt)
        float direction = Mathf.Sign(rb.transform.localScale.x);
        float moveThisFrame = moveSpeed * Time.deltaTime;

        // Cập nhật khoảng cách đã di chuyển
        distanceMoved += moveThisFrame;

        // Áp dụng vận tốc ngang
        rb.velocity = new Vector2(direction * dashSpeed, rb.velocity.y);

        // Dừng di chuyển nếu đã đạt khoảng cách yêu cầu
        if (distanceMoved >= dashDistance)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}
