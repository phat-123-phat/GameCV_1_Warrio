using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class MeleeBaseState : State
{
    public float duration;
    protected Animator animator;
    protected bool shouldCombo;
    protected int attackIndex;
    protected Collider2D hitCollider;
    private List<Collider2D> collidersDamaged;
    private GameObject HitEffectPrefab;
    private float AttackPressedTimer = 0;

    // Thêm các biến để quản lý di chuyển khi tấn công
    protected Rigidbody2D rb;
    protected float moveDistance;
    protected float moveSpeed;
    private float distanceMoved;

    protected StateMachine movementStateMachine;
    protected bool hasAttacked = false;
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        animator = GetComponent<Animator>();
        collidersDamaged = new List<Collider2D>();
        hitCollider = GetComponent<ComboCharacter>().hitbox;
        HitEffectPrefab = GetComponent<ComboCharacter>().Hiteffect;
        rb = GetComponent<Rigidbody2D>();
        distanceMoved = 0f; // Reset khoảng cách đã di chuyển
        hasAttacked = false;
        // Lấy movement StateMachine
        StateMachine[] stateMachines = _stateMachine.GetComponents<StateMachine>();
        foreach (var sm in stateMachines)
        {
            if (sm.customName == "Movement")
            {
                movementStateMachine = sm;
                break;
            }
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        AttackPressedTimer -= Time.deltaTime;

        if (animator.GetFloat("Weapon.Active") > 0f)
        {
            Attack();
            MoveForward(); 
        }
        if (animator.GetFloat("AttackWindow.Open") > 0f && AttackPressedTimer > 0)
        {
            shouldCombo = true;
        }

        if (Input.GetKeyDown(characterSettings.keyAtk))
        {
            AttackPressedTimer = characterSettings.attackPressedTimerDuration;
        }
        if (Input.GetKeyDown(characterSettings.keyJump) && movementStateMachine != null)
        {
            // Chuyển combatStateMachine về IdleCombatState
            stateMachine.SetNextStateToMain();
            // Chuyển movementStateMachine sang JumpMoveme ntState
            movementStateMachine.SetNextState(new JumpMovementState());
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        // Đảm bảo dừng di chuyển ngang khi thoát trạng thái
        if (rb != null)
            rb.velocity = new Vector2(0f, rb.velocity.y);
    }

    protected void Attack()
    {
        Collider2D[] collidersToDamage = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;
        int colliderCount = Physics2D.OverlapCollider(hitCollider, filter, collidersToDamage);
        for (int i = 0; i < colliderCount; i++)
        {
            if (!collidersDamaged.Contains(collidersToDamage[i]))
            {
                TeamComponent hitTeamComponent = collidersToDamage[i].GetComponentInChildren<TeamComponent>();

                if (hitTeamComponent && hitTeamComponent.teamIndex == TeamIndex.Enemy)
                {
                    CharacterHealth enemyHealth = collidersToDamage[i].GetComponent<CharacterHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(characterSettings.meleeDamage);
                    }
                    GameObject.Instantiate(HitEffectPrefab, collidersToDamage[i].transform);
                    collidersDamaged.Add(collidersToDamage[i]);
                }
            }
        }
    }

    protected void MoveForward()
    {
        if (rb == null || distanceMoved >= moveDistance)
            return;

        // Xác định hướng di chuyển dựa trên localScale.x (hướng nhân vật đang đối mặt)
        float direction = Mathf.Sign(rb.transform.localScale.x);
        float moveThisFrame = moveSpeed * Time.deltaTime;

        // Cập nhật khoảng cách đã di chuyển
        distanceMoved += moveThisFrame;

        // Áp dụng vận tốc ngang
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        // Dừng di chuyển nếu đã đạt khoảng cách yêu cầu
        if (distanceMoved >= moveDistance)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
    
}