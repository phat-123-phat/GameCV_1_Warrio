using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCharacter : MonoBehaviour
{
    private StateMachine meleeStateMachine;
    private StateMachine movementStateMachine; 


    public Collider2D hitbox;
    public GameObject Hiteffect;
    public  bool canAttack;
    

    private void Awake()
    {
        meleeStateMachine = GetComponent<StateMachine>(); 

        // Tìm movement StateMachine
        StateMachine[] stateMachines = GetComponents<StateMachine>();
        foreach (var sm in stateMachines)
        {
            if (sm.customName == "Movement")
            {
                movementStateMachine = sm;
                break;
            }
        }
    }

    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.J) && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState) && !IsJumping() && !IsWallSlide() && canAttack)
        {
            if (!IsDashing())
            {
                meleeStateMachine.SetNextState(new GroundEntryState());
                movementStateMachine.SetNextState(new IdleMovementState());
            } else
            {
                meleeStateMachine.SetNextState(new DashAttackState());
                movementStateMachine.SetNextState(new IdleMovementState());
            }
            
        }
    }

    

    private bool IsJumping()
    {
        if (movementStateMachine == null || movementStateMachine.CurrentState == null)
            return false;

        var currentStateType = movementStateMachine.CurrentState.GetType();
        return currentStateType == typeof(JumpMovementState) || currentStateType == typeof(JumpToFallMovementState);
    }
    private bool IsDashing()
    {
        if (movementStateMachine == null || movementStateMachine.CurrentState == null)
            return false;

        var currentStateType = movementStateMachine.CurrentState.GetType();
        return currentStateType == typeof(DashMovementState);
    }
   
    private bool IsWallSlide()
    {
        if (movementStateMachine == null || movementStateMachine.CurrentState == null)
            return false;

        var currentStateType = movementStateMachine.CurrentState.GetType();
        return currentStateType == typeof(WallSlideMovementState);
    }
}