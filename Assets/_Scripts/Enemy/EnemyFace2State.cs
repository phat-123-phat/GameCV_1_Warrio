using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.U2D.Sprites;
using UnityEngine;

public class EnemyFace2State : EnemyBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        EnemyHealth.maxHealth = EnemyHealth.maxHealth * 2;
        animator.SetBool("IsFace2", true);
        enemyCharacter.EnemyAnimation.SetBool("IsFace2", true);
        CameraManager.SwitchCamera(enemyCharacter.camFace2);
        enemyCharacter.Arm.SetActive(true);
        enemyCharacter.laserActive.SetActive(true);
        AudioManager.instance.PlayerMusic(enemyCharacter.MusicBossFace2);

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        EnemyHealth.Healing(10);

        if (EnemyHealth.currentHealth >= EnemyHealth.maxHealth)
        {
           
            stateMachine.SetNextState(new IdleEnemyState());
            isFace2 = true;
        }

    }
     
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsFace2", false);
        enemyCharacter.EnemyAnimation.SetBool("IsFace2", false);
    }
}
