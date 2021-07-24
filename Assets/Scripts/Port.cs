using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Port : MonoBehaviour
{
    [SerializeField]
    float radius = 5f;

    Transform player;
    PlayerManager manager;

    [SerializeField]
    Transform spaceBar;

    bool hasTweened = false;

    void Start()
    {
        player = FindObjectOfType<ShipMovement>().GetComponent<Transform>();
        manager = FindObjectOfType<ShipMovement>().GetComponent<PlayerManager>();
        spaceBar.localScale = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsNearPort())
            {
                if (manager.GetPlayerGold() >= 10)
                {
                    Debug.Log("no");
                    manager.ChangePlayerAmmo(10);
                    manager.ChangePlayerHealth(10);
                    manager.ChangePlayerGold(-10);
                }
            }
        }
        if (IsNearPort())
        {
            if (!hasTweened)
            {
                hasTweened = true;
                spaceBar.DOScale(new Vector3(1f, 1f, 1f), 1);
            }
        }
        else
        {
            if (hasTweened)
            {
                StartCoroutine(TweenAway());
            }
        }
    }

    IEnumerator TweenAway()
    {
        yield return new WaitForSeconds(1f);
        if (! IsNearPort())
        {
            if (hasTweened)
            {
                hasTweened = false;
                spaceBar.DOScale(new Vector3(0, 0, 0), 1);
            }
        }
    }

    bool IsNearPort()
    {
        return Vector2.Distance(player.transform.position, transform.position) < radius;
    }
}
