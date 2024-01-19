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
        // Assurez-vous que le sort réagit uniquement aux collisions avec le joueur
        if (collision.gameObject.layer == GameObject.FindGameObjectWithTag("Player")) ;
        {
            // Gérez la collision avec le joueur ici (par exemple, appliquer des dégâts)
            Destroy(gameObject); // Détruire le sort après la collision
        }
    }
}
