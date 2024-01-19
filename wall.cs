using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour
{
private void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collision detected with " + collision.gameObject.name);
    if (collision.gameObject.CompareTag("Spell"))
    {
        Debug.Log("The wall has been hit by a spell.");
        WallHealth wallHealth = GetComponent<WallHealth>();
        if(wallHealth != null)
        {
            wallHealth.TakeDamage(10);
        }
    }
}

}