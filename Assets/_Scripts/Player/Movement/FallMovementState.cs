using UnityEngine;

public class FallMovementState : MovementBaseState
{
    private float coolDownWallSlide = 0.5f;
    private float _coolDownWallSlide;
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsFalling", true);
        _coolDownWallSlide = coolDownWallSlide;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (_coolDownWallSlide > 0)
        {
            _coolDownWallSlide -= Time.deltaTime;
        }

        if (isGrounded && rb.velocity.y == 0f)
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