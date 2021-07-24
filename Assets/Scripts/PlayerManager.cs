using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private HealthScript healthScript;
    private PlayerAmmo ammoScript;
    [SerializeField] private TextMeshProUGUI AmmoText;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private TextMeshProUGUI GoldText;
    [SerializeField] private int startGold;
    private int gold;

    private void Awake()
    {
        healthScript = GetComponent<HealthScript>();
        ammoScript = GetComponent<PlayerAmmo>();
        gold = startGold;
    }

    void Start()
    {
         UpdateHealthText();
         UpdateAmmoText();
         UpdateGoldText();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("hit Obstacle");
            ChangePlayerHealth(-1);
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
        AmmoText.text = "Ammo: " + ammoScript.GetAmmo();
    }
    
    private void UpdateHealthText()
    {
        HealthText.text = "Health: " + healthScript.GetHealth();
    }

    private void UpdateGoldText()
    {
        GoldText.text = "Gold: " + gold;
        
    }
}
