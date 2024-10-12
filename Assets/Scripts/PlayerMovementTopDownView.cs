using UnityEngine;

public class PlayerMovementTopDownView : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement
    public Rigidbody2D rb; // Le Rigidbody2D du joueur
    public Animator animator; // Référence à l'Animator
    private Vector2 movement; // Le vecteur de déplacement
    private bool isFacingRight = true; // Vérifie si le personnage regarde à droite

    void Update()
    {
        // Récupération des inputs de déplacement
        movement.x = Input.GetAxisRaw("Horizontal"); // Input pour gauche/droite
        movement.y = Input.GetAxisRaw("Vertical");   // Input pour haut/bas

        // Envoie la vitesse au paramètre "Speed" de l'Animator
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Gestion de la rotation du personnage
        if (movement.x > 0 && !isFacingRight)
        {
            Flip(); // Tourne vers la droite
        }
        else if (movement.x < 0 && isFacingRight)
        {
            Flip(); // Tourne vers la gauche
        }
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

    void Flip()
    {
        // Inverse l'échelle sur l'axe X
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Inverse l'axe X
        transform.localScale = theScale;
    }
}
