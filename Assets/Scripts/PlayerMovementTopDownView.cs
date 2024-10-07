using UnityEngine;

public class PlayerMovementTopDownView : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement
    public Rigidbody2D rb; // Le Rigidbody2D du joueur
    private Vector2 movement; // Le vecteur de déplacement

    void Update()
    {
        // Récupération des inputs de déplacement
        movement.x = Input.GetAxisRaw("Horizontal"); // Input pour gauche/droite
        movement.y = Input.GetAxisRaw("Vertical");   // Input pour haut/bas
    }

    void FixedUpdate()
    {
        // Appliquer le déplacement
        MovePlayer();
    }

    void MovePlayer()
    {
        // Applique le mouvement à la vitesse spécifiée
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
