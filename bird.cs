using UnityEngine;

public class BirdFlight : MonoBehaviour
{
    public float moveSpeed = 3f; // Vitesse de déplacement
    public float tiltIntensity = 5f; // Intensité de l'inclinaison
    public float directionChangeInterval = 2f; // Intervalle de changement de direction

    private Vector3 moveDirection; // Direction actuelle du mouvement
    private float directionTimer; // Chronomètre pour le changement de direction
    private int flightBehavior; // Type de comportement de vol

    void Start()
    {
        flightBehavior = Random.Range(0, 3); // Choisissez un comportement de vol aléatoire
        ChangeDirection();
    }

    void Update()
    {
        switch (flightBehavior)
        {
            case 0:
                FlyInCircles();
                break;
            case 1:
                FlyErratically();
                break;
            case 2:
                GlideAndFlap();
                break;
        }
    }

    void FlyInCircles()
    {
        // Vol en cercle avec variations en hauteur
        directionTimer += Time.deltaTime;
        if (directionTimer >= directionChangeInterval)
        {
            float radius = Random.Range(2f, 5f);
            moveDirection = new Vector3(radius, Random.Range(-1f, 1f), 0).normalized;
            directionTimer = 0f;
        }
        MoveAndTilt();
    }

    void FlyErratically()
    {
        // Mouvements erratiques et rapides
        directionTimer += Time.deltaTime;
        if (directionTimer >= directionChangeInterval)
        {
            ChangeDirection();
            directionTimer = 0f;
        }
        MoveAndTilt();
    }

    void GlideAndFlap()
    {
        // Alternance entre glisser et battre des ailes
        directionTimer += Time.deltaTime;
        if (directionTimer >= directionChangeInterval)
        {
            if (Random.value > 0.5f)
            {
                moveDirection = new Vector3(0, -0.5f, 1f).normalized; // Glisser vers le bas
            }
            else
            {
                moveDirection = new Vector3(0, 1f, 0).normalized; // Battre des ailes vers le haut
            }
            directionTimer = 0f;
        }
        MoveAndTilt();
    }

    void ChangeDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void MoveAndTilt()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * tiltIntensity);
    }
}
