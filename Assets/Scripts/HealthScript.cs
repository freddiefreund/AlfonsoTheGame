using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    private int health;
    [SerializeField] private GameObject loot;
    [SerializeField] private int lootRandomTreshold = 50;

    [SerializeField] private int maxHealth;
    [SerializeField] private bool mainShip = false;

    [SerializeField] private RewardListener _listener;
    [SerializeField] private Reward _rewards;

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

    public void Rewarded()
    {
        // Signal our rewards.
        _listener.SignalReward(_rewards);

        // Prevents signaling this task as completed again.
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D colider)
    {
        Debug.Log(colider.name);
        if (colider.gameObject.tag == "Bullet")
        {
            Bullet bullet = colider.gameObject.GetComponent(typeof(Bullet)) as Bullet;
            TakeDamage(bullet.getDamage());
            Destroy(colider.gameObject);
        }

        if (health <= 0)
        {
            if (!mainShip)
            {
                int random = UnityEngine.Random.Range(1, 100);
                if (random > lootRandomTreshold)
                {
                    GameObject tmpObj = Instantiate(loot);
                    tmpObj.transform.position = gameObject.transform.position;
                }
                Destroy(gameObject);
                Rewarded();
            } else
            {
                // respwan
            }
            
        }
    }
}
