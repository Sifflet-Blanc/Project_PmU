using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float damage = 10f;
    public CircleCollider2D attackRange; // Référence au Circle Collider 2D
    private List<EnemyBehaviour> enemiesInRange = new List<EnemyBehaviour>();
    public Animator animator;
    private bool isAttacking = false; // État de l'attaque

    void Start()
    {
        attackRange = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        // Lancer l'attaque en appuyant sur la touche P
        if (Input.GetKeyDown(KeyCode.P) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("isAttacking", true); // Démarrer l'animation

        // Attendre la fin de l'animation avant de désactiver l'attaque
        yield return new WaitForSeconds(0.7f); // Ajuste ce délai selon la durée de l'animation
        
        // Appliquer des dégâts à tous les ennemis dans la zone
        // Créer une copie pour éviter des modifications concurrentes
        List<EnemyBehaviour> enemiesToDamage = new List<EnemyBehaviour>(enemiesInRange); 
        foreach (EnemyBehaviour enemy in enemiesToDamage)
        {
            if (enemy != null) // Vérifier si l'ennemi existe encore
            {
                enemy.TakeDamage(damage);
            }
        }
         // Attendre un court moment avant de réinitialiser l'état d'attaque
        animator.SetBool("isAttacking", false); // Fin de l'animation
        isAttacking = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();

            if (enemy != null && !enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Add(enemy);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();

            if (enemy != null && enemiesInRange.Contains(enemy))
            {
                enemiesInRange.Remove(enemy);
            }
        }
    }
}


