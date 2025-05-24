using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
public class EnemyBaseState : State
{
    protected EnemyCharacter enemyCharacter;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Transform player;
    protected float attackRange;
    protected float detectionRange;
    protected float duration;

    protected static int countShootTime;
    protected int canShootBeforeFill;
    protected EnemyHealth EnemyHealth;

    protected static bool  isFace2 = false;
    protected static bool isDead = false;

   
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        enemyCharacter = GetComponent<EnemyCharacter>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackRange =isFace2 ? Enemysettings.attackRange_f2 : Enemysettings.attackRange;
        detectionRange =isFace2 ? Enemysettings.detectionRange_f2 : Enemysettings.detectionRange;
        EnemyHealth = GetComponent<EnemyHealth>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Debug.Log(DistanceToPlayer());
        if (!(stateMachine.CurrentState is ShootEnemyState) && !(stateMachine.CurrentState is EnemyFillLaserState))
        {
            RotateTowardsPlayer();
        }

        if (EnemyHealth.currentHealth <= 0 )
        {
            
            stateMachine.SetNextState(new DeadEnemyState());
            enemyCharacter.MenuEnd.SetActive(true);
    

        }
       
    }
    protected void RotateTowardsPlayer()
    {
        if (player == null) return;
       float direction = Mathf.Sign(player.position.x - rb.position.x);
        rb.transform.localScale = new Vector3(direction * rb.transform.localScale.y, rb.transform.localScale.y, rb.transform.localScale.z);
    }
    protected float DistanceToPlayer()
    {
        if (player == null) return float.MaxValue;
        return Vector2.Distance(rb.position, player.position);
    }
}
