using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public string xAxisName = "Horizontal";
    public string yAxisName = "Vertical";
    private int Ammo;
    [SerializeField] private TextMeshProUGUI AmmoText;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private HealthScript healthScript;

    [SerializeField] float accelerationPower = 3f;
    [SerializeField] float steeringPower = 0.4f;

    float steeringAmount, speed, direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 0.7f;
        rb.angularDrag = 5f;
        Ammo = 10;
        UpdateAmmoText();
        UpdateHealthText();
    }

    void FixedUpdate()
    {
        steeringAmount = -Input.GetAxis(xAxisName);
        speed = Input.GetAxis(yAxisName) * accelerationPower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * speed);
        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("hit Obstacle");
            ChangePlayerHealth(-1);
        }
    }

    public int GetAmmo()
    {
        return Ammo;
    }

    public void ChangeAmmo(int changeVal)
    {
        Ammo += changeVal;
        UpdateAmmoText();
    }

    public void ChangePlayerHealth(int changeVal)
    {
        healthScript.ChangeHealth(changeVal);
        UpdateHealthText();
    }

    private void UpdateAmmoText()
    {
        AmmoText.text = "Ammo: " + Ammo;
    }

    private void UpdateHealthText()
    {
        HealthText.text = "Health: " + healthScript.GetHealth();
    }
}
