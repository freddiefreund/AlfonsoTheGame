using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    int damage = 10;

    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }

    public int getDamage()
    {
        return damage;
    }
}
