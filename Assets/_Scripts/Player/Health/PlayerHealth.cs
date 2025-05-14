using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int maxHealth;
    int currentHealth;

    public BarCtl BarCtl;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        BarCtl.UpdateBar (currentHealth, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
