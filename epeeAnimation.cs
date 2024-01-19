using UnityEngine;

public class EpeeAnimation : MonoBehaviour
{
    public float bounceHeight = 0.25f;
    public float bounceSpeed = 3.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}