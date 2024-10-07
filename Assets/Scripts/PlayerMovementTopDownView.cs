using UnityEngine;

public class PlayerMovementTopDownView : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement
    public Rigidbody2D rb; // Le Rigidbody2D du joueur
    private Vector2 movement; // Le vecteur de d�placement

    void Update()
    {
        // R�cup�ration des inputs de d�placement
        movement.x = Input.GetAxisRaw("Horizontal"); // Input pour gauche/droite
        movement.y = Input.GetAxisRaw("Vertical");   // Input pour haut/bas
    }

    void FixedUpdate()
    {
        // Appliquer le d�placement
        MovePlayer();
    }

    void MovePlayer()
    {
        // Applique le mouvement � la vitesse sp�cifi�e
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
