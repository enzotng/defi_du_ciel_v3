using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject player; // GameObject pour le joueur VR
    public Camera debutCamera; // Composant Camera pour la caméra de début

    private void Start()
    {
        // Assurez-vous que le joueur VR est désactivé et que la caméra de début est activée au début
        player.SetActive(false);
        debutCamera.gameObject.SetActive(true);
    }

    public void SwitchCamera()
    {
        // Basculer entre le GameObject du joueur et la caméra de début
        bool isPlayerActive = player.activeSelf;
        player.SetActive(!isPlayerActive);
        debutCamera.gameObject.SetActive(isPlayerActive);
    }
}
