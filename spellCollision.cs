using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet de collision a le tag "Mur"
        if (collision.gameObject.CompareTag("Mur"))
        {
            Debug.Log("Le sort a touché le mur!");

            // Récupère le composant WallHealth de l'objet de collision et invoque TakeDamage
            // WallHealth wallHealth = collision.gameObject.GetComponent<WallHealth>();
            // if (wallHealth != null)
            // {
            //     wallHealth.TakeDamage(10); // Assurez-vous que cette valeur de dégâts est appropriée pour votre jeu
            // }
            // else
            // {
            //     Debug.LogError("WallHealth n'est pas trouvé sur la cible!");
            // }

            gameObject.SetActive(false);
        }
    }
}