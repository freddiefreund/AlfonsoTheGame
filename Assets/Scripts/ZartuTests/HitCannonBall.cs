using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCannonBall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D colider)
    {
        Debug.Log(colider.name);
        Destroy(colider.gameObject);
        Destroy(gameObject);
    }
}
