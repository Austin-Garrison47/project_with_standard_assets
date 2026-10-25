
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public int health = 100;

    void Start()
    {
        UpdateHealth();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0);
        UpdateHealth();
    }

    void UpdateHealth()
    {
        healthText.text = "Health: " + health;
    }
}
