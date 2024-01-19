using UnityEngine;

public class SpellCollision : MonoBehaviour
{
    public string targetObjectName; // Nom du GameObject cible

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet de collision est le GameObject cible
        if (collision.gameObject.name == targetObjectName)
        {
            Debug.Log("Le sort a touché la cible!");
            // Ajoutez ici toute action à effectuer lors de la collision avec la cible

            // Optionnel : Détruire le sort après la collision
            Destroy(gameObject);
        }
    }
}
