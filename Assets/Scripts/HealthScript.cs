using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int health;

    [SerializeField] private int maxHealth;
    [SerializeField] private bool mainShip = false;

    private void Awake()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public Boolean isMainShip()
    {
        return mainShip;
    }
    
    public void ChangeHealth(int changeVal)
    {
        health += changeVal;
        if (health > maxHealth)
            health = maxHealth;
        //if(health <= 0)
            //die
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Health after damage: " + health);
    }

}
