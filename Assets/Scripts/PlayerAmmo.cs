using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    private int ammo;
    [SerializeField] private int maxAmmo;

    private void Awake()
    {
        ammo = maxAmmo;
    }

    public int GetAmmo()
    {
        return ammo;
    }

    public void ChangeAmmo(int changeVal)
    {
        ammo += changeVal;
        if (ammo > maxAmmo)
            ammo = maxAmmo;
    }
}
