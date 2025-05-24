using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public CharacterSettings characterSettings;
    public EnemySettings enemySettings;
    public  float maxHealth ;
    public float currentHealth;
    public BarCtl BarCtl;
    void Start()
    {
        currentHealth = maxHealth;
        BarCtl.UpdateBar (currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage); 
        BarCtl.UpdateBar(currentHealth, maxHealth);
       
    }

    public void Healing(float heal)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + heal); 
        BarCtl.UpdateBar(currentHealth, maxHealth);
    }

}
