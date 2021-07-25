using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private HealthScript healthScript;
    private PlayerAmmo ammoScript;
    [SerializeField] private GameObject loot;
    [Range(1, 100)]
    [SerializeField] private int _getLootMinTreshold = 50;
    [SerializeField] private TextMeshProUGUI AmmoText;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private TextMeshProUGUI GoldText;
    [SerializeField] private int startGold;
    [SerializeField] private RewardListener _listener;
    [SerializeField] private Reward _rewards;

    private int gold;

    private void Awake()
    {
        healthScript = GetComponent<HealthScript>();
        ammoScript = GetComponent<PlayerAmmo>();
        gold = startGold;
    }

    void Start()
    {
        if (healthScript.isMainShip())
        {
            UpdateHealthText();
            UpdateAmmoText();
            UpdateGoldText();
        }
    }

    public void Rewarded()
    {
        // Signal our rewards.
        _listener.SignalReward(_rewards);

        // Prevents signaling this reward as gained again.
        //Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected: " + other.gameObject.name );

        Collider2D colider = other.collider;
        Debug.Log("Colider " + colider.tag);
        if (colider.tag == "Bullet")
        {
            Debug.Log("Hit by a bullet!");
            Bullet bullet = colider.gameObject.GetComponent(typeof(Bullet)) as Bullet;
            healthScript.TakeDamage(bullet.getDamage());
            UpdateHealthText();
            Destroy(colider.gameObject);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("hit Obstacle");
            ChangePlayerHealth(-1);
            Debug.Log(gameObject.name + " has health: " + GetPlayerHealth());
        }

        if (GetPlayerHealth() <= 0 && !healthScript.isMainShip())
        {
            int random = UnityEngine.Random.Range(1, 100);
            if (random > _getLootMinTreshold)
            {
                GameObject tmpObj = Instantiate(loot);
                tmpObj.transform.position = gameObject.transform.position;
                
            }
            Destroy(gameObject);
            Rewarded();
        }
        else if (GetPlayerHealth() <= 0)
        {
            //TODO respwan
        }
    }

    public int GetPlayerHealth()
    {
        return healthScript.GetHealth();
    }
    public void ChangePlayerHealth(int changeVal)
    {
        healthScript.ChangeHealth(changeVal);
        UpdateHealthText();
    }

    public int GetPlayerGold()
    {
        return gold;
    }

    public void ChangePlayerGold(int changeVal)
    {
        gold += changeVal;
        UpdateGoldText();
    }

    public int GetPlayerAmmo()
    {
        return ammoScript.GetAmmo();
    }

    public void ChangePlayerAmmo(int changeVal)
    {
        ammoScript.ChangeAmmo(changeVal);
        UpdateAmmoText();
    }
    
    private void UpdateAmmoText()
    {
        if (healthScript.isMainShip())
        {
            AmmoText.text = "Ammo: " + ammoScript.GetAmmo();
        }
    }
    
    private void UpdateHealthText()
    {
        if (healthScript.isMainShip())
        {
            HealthText.text = "Health: " + healthScript.GetHealth();
        }
    }

    private void UpdateGoldText()
    {
        if (healthScript.isMainShip())
        {
            GoldText.text = "Gold: " + gold;
        }
        
    }
}
