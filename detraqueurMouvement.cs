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

    public AudioClip deathSound;
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeDirection();
        spellTimer = Random.Range(minSpellDelay, maxSpellDelay);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = deathSound;
            audioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        AdjustSpeedAndDirection();
        MoveAndTilt();
        CastSpellIfNeeded();
    }

    void AdjustSpeedAndDirection()
    {
        moveSpeed = Random.Range(0.5f, 2.0f);
        changeDirectionInterval = Random.Range(3f, 7f);

        if (lerpTimer < lerpTime)
        {
            randomDirection = Vector3.Lerp(randomDirection, targetDirection, lerpTimer / lerpTime);
            lerpTimer += Time.deltaTime;
        }

        if (timer >= changeDirectionInterval)
        {
            ChangeDirection();
            timer = 0.0f;
            lerpTimer = 0.0f;
        }

        timer += Time.deltaTime;
    }

    void MoveAndTilt()
    {
        Vector3 newPosition = transform.position + randomDirection * moveSpeed * Time.deltaTime;
        newPosition.y = Mathf.Max(newPosition.y, 11f);
        transform.position = newPosition;

        Quaternion targetRotation = Quaternion.LookRotation(randomDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lerpTime * Time.deltaTime);
    }


    void CastSpellIfNeeded()
    {
        spellTimer -= Time.deltaTime;
        if (spellTimer <= 0)
        {
            CastSpellAtPlayer();
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            float delay = Mathf.Lerp(minSpellDelay / 2f, maxSpellDelay / 2f, distanceToPlayer / 8f);
            spellTimer = Mathf.Clamp(delay, minSpellDelay, maxSpellDelay);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spell"))
        {
            Debug.Log("Détraqueur touché par un sort!");

            GameObject murDestruction = GameObject.Find("MurDestruction");
            if (murDestruction != null)
            {
                murDestruction.SetActive(false);
            }
            else
            {
                Debug.LogError("GameObject 'MurDestruction' non trouvé dans la scène!");
            }

            Destroy(gameObject);
        }
    }

    void ChangeDirection()
    {
        targetDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        targetDirection.Normalize();
    }

    void CastSpellAtPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.LookRotation(playerPosition - transform.position));
        Rigidbody spellRigidbody = spell.GetComponent<Rigidbody>();
        Vector3 spellDirection = (playerPosition - transform.position).normalized;
        spellRigidbody.AddForce(spellDirection * 20f, ForceMode.VelocityChange);
    }
}
