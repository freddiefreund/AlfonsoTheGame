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

    [SerializeField]
    Transform spaceBar;

    bool hasTweened = false;

    void Start()
    {
        player = FindObjectOfType<ShipMovement>().GetComponent<Transform>();
        spaceBar.localScale = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        if (isNearPort())
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
        if (! isNearPort())
        {
            if (hasTweened)
            {
                hasTweened = false;
                spaceBar.DOScale(new Vector3(0, 0, 0), 1);
            }
        }
    }

    bool isNearPort()
    {
        return Vector2.Distance(player.transform.position, transform.position) < radius;
    }
}
