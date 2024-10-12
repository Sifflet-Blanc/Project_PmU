using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;
    public Gradient gradient;
    public Image fill;
    public SpriteRenderer enemy;

    public float maxHealth = 100;

    public void SetMaxHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;
        this.maxHealth = maxHealth;
        slider.gameObject.SetActive(false);

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        slider.gameObject.SetActive(health < maxHealth);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Update()
    {
         if (enemy != null)
         {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(enemy.transform.position + offset);
            slider.transform.position = screenPosition; // Positionne la barre de vie
         }
    }
}
