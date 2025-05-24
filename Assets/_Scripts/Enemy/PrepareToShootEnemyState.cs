using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareToShootEnemyState : EnemyBaseState
{
    float deplayShoot;
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator.SetBool("PrepareToShoot", true);
        enemyCharacter.laserAnimator.SetBool("PrepareToShoot", true);
        enemyCharacter.laserAnimator1.SetBool("PrepareToShoot", true);
        enemyCharacter.laserAnimator2.SetBool("PrepareToShoot", true);
        enemyCharacter.laserAnimator3.SetBool("PrepareToShoot", true);
        enemyCharacter.laserAnimator4.SetBool("PrepareToShoot", true);
        enemyCharacter.WarningLaserAnimator.SetBool("IsWarning", true);
        enemyCharacter.WarningLaserAnimator1.SetBool("IsWarning", true);
        enemyCharacter.WarningLaserAnimator2.SetBool("IsWarning", true);
        enemyCharacter.WarningLaserAnimator3.SetBool("IsWarning", true);
        enemyCharacter.WarningLaserAnimator4.SetBool("IsWarning", true);
        duration = Enemysettings.durationPrepareToShoot;
        deplayShoot = Enemysettings.deplayShoot;
       


    }
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedtime <= duration)
        {
            if (enemyCharacter.laser != null && player != null)
            {
                Vector2 direction = (player.position - (Vector3)enemyCharacter.laser.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                enemyCharacter.laser.rotation = angle;
            }
        }
        

        if (fixedtime >= duration + deplayShoot )
        {
            stateMachine.SetNextState(new ShootEnemyState());
        }
        if (fixedtime >= duration)
        {
            enemyCharacter.WarningLaserAnimator.SetBool("IsBling", true);
            enemyCharacter.WarningLaserAnimator1.SetBool("IsBling", true);
            enemyCharacter.WarningLaserAnimator2.SetBool("IsBling", true);
            enemyCharacter.WarningLaserAnimator3.SetBool("IsBling", true);
            enemyCharacter.WarningLaserAnimator4.SetBool("IsBling", true);
        }

        if (isFace2)
        {
            Vector2 direction1 = (enemyCharacter.Tagert1.position - (Vector3)enemyCharacter.laser1.position).normalized;
            float angle1 = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
            enemyCharacter.laser1.rotation = angle1;

            Vector2 direction2 = (enemyCharacter.Tagert2.position - (Vector3)enemyCharacter.laser2.position).normalized;
            float angle2 = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
            enemyCharacter.laser2.rotation = angle2;

            Vector2 direction3 = (enemyCharacter.Tagert3.position - (Vector3)enemyCharacter.laser3.position).normalized;
            float angle3 = Mathf.Atan2(direction3.y, direction3.x) * Mathf.Rad2Deg;
            enemyCharacter.laser3.rotation = angle3;

            Vector2 direction4 = (enemyCharacter.Tagert4.position - (Vector3)enemyCharacter.laser4.position).normalized;
            float angle4 = Mathf.Atan2(direction4.y, direction4.x) * Mathf.Rad2Deg;
            enemyCharacter.laser4.rotation = angle4;
        }

    }

    public override void OnExit()
    {
        base.OnExit();
        animator.SetBool("PrepareToShoot", false);
        enemyCharacter.laserAnimator.SetBool("PrepareToShoot", false);
        enemyCharacter.laserAnimator1.SetBool("PrepareToShoot", false);
        enemyCharacter.laserAnimator2.SetBool("PrepareToShoot", false);
        enemyCharacter.laserAnimator3.SetBool("PrepareToShoot", false);
        enemyCharacter.laserAnimator4.SetBool("PrepareToShoot", false);
        enemyCharacter.WarningLaserAnimator.SetBool("IsWarning", false);
        enemyCharacter.WarningLaserAnimator1.SetBool("IsWarning", false);
        enemyCharacter.WarningLaserAnimator2.SetBool("IsWarning", false);
        enemyCharacter.WarningLaserAnimator3.SetBool("IsWarning", false);
        enemyCharacter.WarningLaserAnimator4.SetBool("IsWarning", false);
        enemyCharacter.WarningLaserAnimator.SetBool("IsBling", false);
        enemyCharacter.WarningLaserAnimator1.SetBool("IsBling", false);
        enemyCharacter.WarningLaserAnimator2.SetBool("IsBling", false);
        enemyCharacter.WarningLaserAnimator3.SetBool("IsBling", false);
        enemyCharacter.WarningLaserAnimator4.SetBool("IsBling", false);
    }
    
    public void RotateLaser(Rigidbody2D Laser, Transform target)
    {
        Vector2 direction = (target.position - (Vector3)Laser.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Laser.rotation = angle;
    }
}
