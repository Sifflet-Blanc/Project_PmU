using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private float damage = 10;
    public CircleCollider2D attackRange; // R�f�rence au Circle Collider 2D
                                         
    void Start()
    {
        // Obtenez la r�f�rence au Circle Collider 2D attach� � ce GameObject
        attackRange = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cette m�thode est appel�e quand un collider sort de la zone du collider (trigger)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // V�rifie si l'objet sort est un ennemi
        {
            EnemyBehaviour enemy = other.transform.GetComponent<EnemyBehaviour>();
            enemy.TakeDamage(damage);
        }
    }
}
