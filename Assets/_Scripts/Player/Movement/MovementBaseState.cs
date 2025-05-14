using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementBaseState : State
{
    protected MovementCharacter movementCharacter;
    public float duration;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected float distanceToGround;
    protected float distanceToWall;
    protected float moveInput;

    protected float jumpPressedTimer ;
  
    protected float moveSpeed;
    protected float dashPressedTimer;
    protected StateMachine combatStateMachine;


    protected Transform checkGroundPos;
    
    protected float groundCheckRadius;
    protected LayerMask groundLayer;

  

    protected Transform checkWallPos;
    protected float wallCheckRadius;
    protected LayerMask wallLayer;

    

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        movementCharacter = GetComponent<MovementCharacter>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpPressedTimer = settings.jumpPressedTimer;
        checkGroundPos = movementCharacter.checkGroundPos;
        groundCheckRadius = settings.groundCheckRadius;
        groundLayer = settings.groundLayer;
        checkWallPos = movementCharacter.checkWallPos;
        wallCheckRadius = settings.wallCheckRadius;
        wallLayer = settings.wallLayer;
        moveSpeed = settings.moveSpeed;
        dashPressedTimer = settings.dashPressedTimer;
        StateMachine[] stateMachines = _stateMachine.GetComponents<StateMachine>();
        foreach (var sm in stateMachines)
        {
            if (sm.customName == "Combat")
            {
                combatStateMachine = sm;
                break;
            }
        }
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        UpdateGroundCheck();
        UpdateWallCheck();
        PlayerRun();
        RotateDirection();
       
        moveInput = Input.GetAxisRaw("Horizontal");
        if (duration >0)
        {
            duration -= Time.deltaTime;
        }
        
        if (jumpPressedTimer > 0)
        {
            jumpPressedTimer -= Time.deltaTime;

        }
        if (dashPressedTimer > 0)
        {
            dashPressedTimer -= Time.deltaTime;

        }
       

    }
    public override void OnExit()
    {
        base.OnExit();
    }
    protected void UpdateGroundCheck()
    {
        if (rb == null) return;

        isGrounded = Physics2D.OverlapCircle( checkGroundPos.transform.position, groundCheckRadius, groundLayer);

        
    }

    protected void UpdateWallCheck()
    {
        if (rb == null) return;
        isTouchingWall = false;

        if (Physics2D.OverlapCircle(checkWallPos.transform.position, wallCheckRadius, wallLayer))
        {
            isTouchingWall = true;
        }
        
    }

    public void PlayerRun()
    {
        if (!IsAttacking() && !(stateMachine.CurrentState is DashMovementState) && !(stateMachine.CurrentState is HurtMovementState))
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
    }
    public void RotateDirection()
    {
        if (moveInput != 0)
        {
            if (!IsAttacking() && !(stateMachine.CurrentState is DashMovementState))
            {
                rb.transform.localScale = new Vector3(Mathf.Sign(moveInput), rb.transform.localScale.y, rb.transform.localScale.z);
            }
        }
    }

    protected bool IsAttacking()
    {
        if (combatStateMachine == null || combatStateMachine.CurrentState == null)
            return false;

        var currentStateType = combatStateMachine.CurrentState.GetType();
        return currentStateType == typeof(GroundEntryState) ||
               currentStateType == typeof(GroundComboState) ||
               currentStateType == typeof(GroundFinisherState) ||
               currentStateType == typeof(DashAttackState);
    }


   


}
