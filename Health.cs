using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLife : MonoBehaviour
{
    public int curHealth = 100;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public Transform steamVRCamera;

    void Start()
    {
        curHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth(curHealth);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DamagePlayer(10);
        }

        if (steamVRCamera != null)
        {
            transform.LookAt(steamVRCamera);
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        curHealth = Mathf.Clamp(curHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(curHealth);
        }
    }
}