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

    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    private void OnTriggerEnter2D(Collider2D colider)
    {
        Debug.Log(colider.name);
        Bullet bullet = colider.gameObject.GetComponent(typeof(Bullet)) as Bullet;
        TakeDamage(bullet.getDamage());
        Destroy(colider.gameObject);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
