using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0, 10, 0) * Time.deltaTime);
    }
}
