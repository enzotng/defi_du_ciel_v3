using UnityEngine;

public class SpellGuidance : MonoBehaviour
{
    public float speed = 100f;
    private GameObject target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION");
        // Vérifiez si l'objet de collision a le tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("COLLISION AVEC LE JOUEUR");
            // Gérez la collision avec le joueur ici (par exemple, appliquer des dégâts)
            Destroy(gameObject, 50f); // Détruire le sort après la collision
        }
    }
}
