using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    int damage = 10;

    [SerializeField]
    bool autoAttack = false;

    [SerializeField] private float speed;

    private void Start()
    {
        gameObject.tag = "Bullet";
    }

    void Update()
    {
        transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
    }

    public bool isAutoAttackOn()
    {
        return autoAttack;
    }

    public int getDamage()
    {
        return damage;
    }
}
