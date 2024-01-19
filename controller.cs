using UnityEngine;
using Valve.VR;

public class SpellCasting : MonoBehaviour
{
    public SteamVR_Action_Boolean castSpellAction;
    public SteamVR_Action_Boolean castSecondSpellAction;
    public GameObject spellPrefab;
    public GameObject secondSpellPrefab;
    public AudioClip spellSound;
    public AudioClip secondSpellSound;
    private AudioSource audioSource;
    private SteamVR_Behaviour_Pose pose;

    void Start()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        audioSource = GetComponent<AudioSource>();
        if (!audioSource)
        {
            Debug.LogError("Il manque un composant AudioSource sur le script SpellCasting.");
        }
    }

    void Update()
    {
        if (castSpellAction.GetStateDown(pose.inputSource))
        {
            CastSpell(1);
            Debug.Log("Sort 1 lancé.");
        }

        if (castSecondSpellAction.GetState(pose.inputSource))
        {
            CastSpell(2);
            Debug.Log("Maintien pour Sort 2 détecté.");
        }
        else if (castSecondSpellAction.GetStateUp(pose.inputSource))
        {
            Debug.Log("Arrêt du maintien pour Sort 2 détecté.");
        }
    }

    void CastSpell(int spellType)
    {
        GameObject spell = null;
        Vector3 spawnPosition = pose.transform.position
                        + pose.transform.forward * 0.75f
                        + new Vector3(0, 0.2f, 0);

        if (spellType == 1)
        {
            spell = Instantiate(spellPrefab, spawnPosition, pose.transform.rotation * Quaternion.Euler(0, 180, 180));
            audioSource.PlayOneShot(spellSound);
        }
        else if (spellType == 2)
        {
            spell = Instantiate(secondSpellPrefab, spawnPosition, pose.transform.rotation * Quaternion.Euler(0, 180, 180));
            audioSource.PlayOneShot(secondSpellSound);
        }

        if (spell != null)
        {
            Rigidbody spellRigidbody = spell.GetComponent<Rigidbody>();
            if (spellRigidbody != null)
            {
                spellRigidbody.AddForce(pose.transform.forward * 10f, ForceMode.VelocityChange);
                Destroy(spell, 5.0f);
            }
        }
    }
}