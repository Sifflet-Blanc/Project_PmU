using UnityEngine;
using System.Collections;

public class CharacterHealth : MonoBehaviour
{
    public int MAXHEALTH = 100;
    public int currentHealth;
    public SpriteRenderer graphics;
    public HealthBar healthBar;

    protected virtual void Start()
    {
        currentHealth = MAXHEALTH;
        healthBar.SetMaxHealth(MAXHEALTH);
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}

