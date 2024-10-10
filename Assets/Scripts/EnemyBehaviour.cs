using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public HealthBarBehaviour healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            Destroy(gameObject);
            healthBar.slider.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        // Si la touche "K" est press�e, le serpent prend des d�g�ts
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10); // Le serpent prend 10 points de d�g�ts
        }
    }

}
