using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemyState : EnemyBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsDead", true);
        duration  = Enemysettings.durationDead;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
       if (fixedtime >= 0.5)
            Destroy(enemyCharacter.gameObject);
            enemyCharacter.HealthBar.SetActive(false);
        
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
