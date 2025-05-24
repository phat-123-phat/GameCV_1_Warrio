using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = characterSettings.maxHealth;
        currentHealth = maxHealth;
        BarCtl.UpdateBar(currentHealth, maxHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (characterSettings.damageTags.Contains(collision.tag))
        {
            TakeDamage(enemySettings.laserDamageEnter);
   
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (characterSettings.damageTags.Contains(collision.tag))
        {
            TakeDamage(enemySettings.laserDamageStay);
        }
    }

}
