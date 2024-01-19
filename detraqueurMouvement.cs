using UnityEngine;

public class EnnemiDeTraqueur : MonoBehaviour
{
    public GameObject spellPrefab;
    public float minSpellDelay = 1f;
    public float maxSpellDelay = 5f;
    private float moveSpeed;
    private float changeDirectionInterval;
    private GameObject player;
    private Vector3 randomDirection;
    private Vector3 targetDirection;
    private float timer;
    private float lerpTime = 1.0f;
    private float lerpTimer = 0.0f;
    private float spellTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeDirection();
        spellTimer = Random.Range(minSpellDelay, maxSpellDelay);
    }

    void Update()
    {
        AdjustSpeedAndDirection();
        MoveAndTilt();
        CastSpellIfNeeded();
    }

    void AdjustSpeedAndDirection()
    {
        // Votre logique existante pour ajuster la vitesse et la direction
    }

    void MoveAndTilt()
    {
        // Votre logique existante pour le mouvement et l'inclinaison
    }

    void CastSpellIfNeeded()
    {
        // Votre logique existante pour lancer des sorts si nécessaire
    }

    void ChangeDirection()
    {
        // Votre logique existante pour changer de direction
    }

    void CastSpellAtPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.LookRotation(playerPosition - transform.position));
        Rigidbody spellRigidbody = spell.GetComponent<Rigidbody>();
        Vector3 spellDirection = (playerPosition - transform.position).normalized;
        spellRigidbody.AddForce(spellDirection * 10f, ForceMode.VelocityChange);
    }
}
