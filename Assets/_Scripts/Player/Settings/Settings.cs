using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings", order = 1)]
public class Settings : ScriptableObject
{
    [Header("General Settings")]
    public KeyCode keyAtk = KeyCode.J;
    public float attackPressedTimerDuration = 2f;

    [Header("Raycast check")]
    
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer ;
    
    public float wallCheckRadius = 0.2f;
    public LayerMask wallLayer ;

    [Header("Dash Attack State")]
    public float DashAttackDuration = 0.5f;
    public string DashAttackAttackIndex = "Dash";
    public float DashAttackMoveDistance = 0f;
    public float DashAttackMoveSpeed = 0f;

    [Header("Ground Entry State")]
    public float groundEntryDuration = 0.5f;
    public int groundEntryAttackIndex = 1;
    public float groundEntryMoveDistance = 2f; 
    public float groundEntryMoveSpeed = 5f;    

    [Header("Ground Combo State")]
    public float groundComboDuration = 0.5f;
    public int groundComboAttackIndex = 2;
    public float groundComboMoveDistance = 1.5f; 
    public float groundComboMoveSpeed = 4f;      

    [Header("Ground Finisher State")]
    public float groundFinisherDuration = 0.5f;
    public int groundFinisherAttackIndex = 3;
    public float groundFinisherMoveDistance = 3f; 
    public float groundFinisherMoveSpeed = 6f;   

    [Header("Player Run")]
    public float moveSpeed = 7f;

    [Header("Player Jump")]
    public float jumpForce = 7f;
    public float jumpPressedTimer = 2f;
    public KeyCode keyJump = KeyCode.K;

    [Header("Player Dash")]
    public float dashDuration = 0.5f;
    public float dashPressedTimer = 2f;
    public float dashSpeed = 7f;
    public float dashDistance = 2f;
    public KeyCode keyDash = KeyCode.L;

    [Header("Player Wall Jump")]
    public Vector2 wallJumpPower = new Vector2(7f, 15f);
    public float wallJumpAngle = 45f; // Góc nhảy tường (độ)

    [Header("Player Hurt")]
    public float hurtDuration = 0.5f; // Thời gian trạng thái bị thương
    public Vector2 hurtKnockbackForce = new Vector2(5f, 5f); // Lực đẩy lùi
    public List<string> damageTags = new List<string> { "Trap", "Enemy", "Hazard" };
}