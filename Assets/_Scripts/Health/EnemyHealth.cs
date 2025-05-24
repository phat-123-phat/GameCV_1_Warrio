using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyHealth : CharacterHealth
{
    void Start()
    {
        maxHealth = enemySettings.maxHealth;
        currentHealth = maxHealth;
        BarCtl.UpdateBar(currentHealth, maxHealth);
    }
}
