using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private float damage = 10;
    public CircleCollider2D attackRange; // Référence au Circle Collider 2D
                                         
    void Start()
    {
        // Obtenez la référence au Circle Collider 2D attaché à ce GameObject
        attackRange = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cette méthode est appelée quand un collider sort de la zone du collider (trigger)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Vérifie si l'objet sort est un ennemi
        {
            EnemyBehaviour enemy = other.transform.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage(damage);
        }
    }
}
