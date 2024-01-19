using UnityEngine;

public class BirdFlight2 : MonoBehaviour
{
    public float baseRadius = 5f; // Rayon de base du cercle
    public float speed = 1f; // Vitesse de vol de l'oiseau
    public float tiltIntensity = 5f; // Intensité de l'inclinaison

    private float angle = 0f; // Angle actuel autour du cercle
    private Vector3 centerPoint; // Point central autour duquel l'oiseau va voler
    private Vector3 lastPosition; // Dernière position pour calculer la direction

    void Start()
    {
        centerPoint = transform.position; // Position initiale comme point central
        lastPosition = transform.position;
    }

    void Update()
    {
        angle += speed * Time.deltaTime; // Augmenter l'angle en fonction de la vitesse et du temps écoulé

        float radius = baseRadius + Mathf.Sin(Time.time) * 0.5f; // Variation du rayon
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;
        float y = centerPoint.y + Mathf.Sin(Time.time * 0.5f) * 2f; // Mouvement vertical ondulant

        Vector3 newPosition = new Vector3(x, y, z) + centerPoint;
        transform.position = newPosition;

        // Calculer la direction inversée en fonction de la position précédente
        Vector3 direction = lastPosition - newPosition; // Inversion de la direction
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * tiltIntensity);
        }

        lastPosition = transform.position; // Mise à jour de la dernière position
    }
}
