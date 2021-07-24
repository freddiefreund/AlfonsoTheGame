using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]
    KeyCode shootKey;

    [SerializeField]
    Bullet bullet;

    private PlayerManager player;

    private void Start()
    {
        player = GetComponentInParent<PlayerManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Debug.Log("shoot");
            if (player.GetPlayerAmmo() > 0)
            {
                Bullet ball = Instantiate(bullet, transform.position, transform.rotation);
                player.ChangePlayerAmmo(-1);
            }
        }
    }
}
