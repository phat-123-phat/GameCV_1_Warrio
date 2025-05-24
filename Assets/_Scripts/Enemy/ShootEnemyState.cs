using FirstGearGames.SmoothCameraShaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyState : EnemyBaseState
{
    
    
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("IsShoot", true);
        enemyCharacter.laserAnimator.SetBool("IsShoot", true);
        enemyCharacter.laserAnimator1.SetBool("IsShoot", true);
        enemyCharacter.laserAnimator2.SetBool("IsShoot", true);
        enemyCharacter.laserAnimator3.SetBool("IsShoot", true);
        enemyCharacter.laserAnimator4.SetBool("IsShoot", true);
        duration = Enemysettings.durationShoot;
        canShootBeforeFill = Enemysettings.canShootBeforeFill;
        countShootTime++;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        CameraShakerHandler.Shake(enemyCharacter.laserShakeData);
        if (fixedtime > duration)
        {
            if (countShootTime > canShootBeforeFill)
            {
                stateMachine.SetNextState(new EnemyFillLaserState());
                countShootTime = 0;
            }
            else
            {
                stateMachine.SetNextState(new IdleEnemyState());
            }
        }
        
        
    }
    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("IsShoot", false);
        enemyCharacter.laserAnimator.SetBool("IsShoot", false);
        enemyCharacter.laserAnimator1.SetBool("IsShoot", false);
        enemyCharacter.laserAnimator2.SetBool("IsShoot", false);
        enemyCharacter.laserAnimator3.SetBool("IsShoot", false);
        enemyCharacter.laserAnimator4.SetBool("IsShoot", false);
    }

    
    
}
