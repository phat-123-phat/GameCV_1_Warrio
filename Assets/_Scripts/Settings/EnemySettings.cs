using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemySettings", menuName = "Settings/EnemySettings", order = 1)]
public class EnemySettings : ScriptableObject
{
    [Header("Face 1")]
    [Header("Movement Settings")]
    public float detectionRange = 10f; // Phạm vi phát hiện người chơi
    public float attackRange = 2f; // Phạm vi tấn công

    [Header("Attack Settings")]
    public float durationPrepareToShoot = 3f;
    public float durationShoot = 3f;
    public float durationMelee = 3f;
    public float deplayShoot = 0.5f;
    public int canShootBeforeFill = 3;

    public float laserDamageEnter= 3f;
    public float laserDamageStay = 0.1f;

    [Header("Enemy Fill Mana")]
    public float durationFillMana = 3f;
    public float durationReturnShoot = 1.5f;

    [Header("Enemy Hurt")]
    public List<string> damageTags = new List<string> { "PlayerDamage" };

    [Header("Enemy Health")]
    public float maxHealth = 2000;

    [Header("Face 2")]
    [Header("Movement Settings")]
    public float detectionRange_f2 = 10f; // Phạm vi phát hiện người chơi
    public float attackRange_f2 = 2f; // Phạm vi tấn công

    [Header("Attack Settings")]
    public float durationPrepareToShoot_f2 = 3f;
    public float durationShoot_f2 = 3f;
    public float durationMelee_f2 = 3f;
    public float deplayShoot_f2 = 0.5f;
    public int canShootBeforeFill_f2 = 3;

    public float laserDamageEnter_f2 = 3f;
    public float laserDamageStay_f2 = 0.1f;

    [Header("Enemy Fill Mana")]
    public float durationFillMana_f2 = 3f;
    public float durationReturnShoot_f2 = 1.5f;

    [Header("Enemy Dead")]
    public float durationDead = 2.5f;

}
