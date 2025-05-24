using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtMovementState : MovementBaseState
{
    private Vector2 knockbackForce;
    

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        duration = characterSettings.hurtDuration;
        knockbackForce = characterSettings.hurtKnockbackForce;
        // Phát animation bị thương
        animator.SetTrigger("IsHurt");

        // Áp dụng lực đẩy lùi
        ApplyKnockback();

        //AudioManager.instance.PlayerSFX("Hurt");

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime >= duration)
        {
            if (isGrounded)
            {
                stateMachine.SetNextState(new IdleMovementState());
                combatStateMachine.SetNextStateToMain();
            }
            else
            {
                stateMachine.SetNextState(new FallMovementState());
                combatStateMachine.SetNextStateToMain();
            }
        }
        if (playerHealth.currentHealth <= 0)
        {
            movementCharacter.MenuDead.SetActive(true);
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        // Đặt lại vận tốc ngang để tránh trượt
        rb.velocity = new Vector2(0f, rb.velocity.y);
        animator.ResetTrigger("IsHurt");
    }

    private void ApplyKnockback()
    {
        
        float direction = rb.transform.localScale.x;
        rb.velocity = new Vector2(-direction * knockbackForce.x, knockbackForce.y);
    }
}
