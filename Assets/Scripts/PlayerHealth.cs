using UnityEngine;
using System.Collections;

public class PlayerHealth : CharacterHealth
{   
    public float invincibilityTimeAfterHit = 3f;
    public float invicibilityFlashDelay = 0.15f;
    public bool isInvicible = false;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is no more instance of GameOverManager in this scene");
            return;
        }

        instance = this;
    }


    public override void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Debug.Log("Player is dead");
        LevelManager.instance.OnPlayerDeath();
        gameObject.SetActive(false);
    }

    public IEnumerator InvicibilityFlash()
    {
        while(isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvicible = false;
    }


}
