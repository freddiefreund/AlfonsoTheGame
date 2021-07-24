using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]
    KeyCode shootKey;

    [SerializeField]
    Bullet bullet;

    [SerializeField] private ShipMovement player;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Debug.Log("shoot");
            if (player.GetAmmo() > 0)
            {
                Bullet ball = Instantiate(bullet, transform.position, transform.rotation);
                player.ChangeAmmo(-1);
            }
        }
    }
}
