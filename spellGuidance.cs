using UnityEngine;

public class SpellGuidance : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    private GameObject target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifiez si l'objet de collision a le tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Gérez la collision avec le joueur ici (par exemple, appliquer des dégâts)
            Destroy(gameObject, 50f); // Détruire le sort après la collision
        }
    }
}
