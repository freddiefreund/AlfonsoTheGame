using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int health;

    [SerializeField] private int maxHealth;

    private void Awake()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }
    
    public void ChangeHealth(int changeVal)
    {
        health += changeVal;
        if (health > maxHealth)
            health = maxHealth;
        //if(health <= 0)
            //die
    }
}
