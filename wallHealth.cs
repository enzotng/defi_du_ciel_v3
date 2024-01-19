using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }
}