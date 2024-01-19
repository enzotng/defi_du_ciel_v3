using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
    public float regenDelay = 5.0f;

private void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collision détectée avec " + collision.gameObject.name);
    if (collision.gameObject.CompareTag("Spell"))
    {
        Debug.Log("Le mur a été touché par un sort.");
        gameObject.SetActive(false);
        StartCoroutine(RegenerateWall());
    }
}


    private IEnumerator RegenerateWall()
    {
        yield return new WaitForSeconds(regenDelay);
        gameObject.SetActive(true);
    }
}