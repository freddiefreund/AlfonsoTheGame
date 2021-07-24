using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]
    KeyCode shootKey;

    [SerializeField]
    Bullet bullet;

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Debug.Log("shoot");
            Bullet ball = Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
