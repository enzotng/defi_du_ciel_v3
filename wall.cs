using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Spell"))
        {
            Debug.Log("The wall has been hit by a spell.");
            
            // Désactive le GameObject mur
            gameObject.SetActive(false);
        }
    }
}