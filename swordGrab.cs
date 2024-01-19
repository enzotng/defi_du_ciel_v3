using UnityEngine;
using Valve.VR;

public class SwordGrab : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Behaviour_Pose pose;
    private GameObject attachedSword;

    private void Awake()
    {
        grabAction.AddOnChangeListener(OnGrabActionChange, pose.inputSource);
    }

    private void OnGrabActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
    {
        // Si l'action est activée et qu'aucune épée n'est actuellement attachée
        if (newValue && attachedSword == null)
        {
            TryGrabSword();
        }
        // Si l'action est désactivée et qu'une épée est attachée
        else if (!newValue && attachedSword != null)
        {
            ReleaseSword();
        }
    }

    private void TryGrabSword()
    {
        // Trouver l'épée dans la scène
        GameObject sword = GameObject.Find("Epee");
        if (sword != null)
        {
            // Attacher l'épée à la main
            attachedSword = sword;
            attachedSword.transform.SetParent(pose.transform);
            attachedSword.transform.localPosition = Vector3.zero; // Ou ajustez en fonction de la position préférée
            attachedSword.transform.localRotation = Quaternion.identity; // Ou ajustez en fonction de l'orientation préférée

            // Désactiver le modèle de la main par défaut, s'il y en a un
        var handRenderer = pose.GetComponentInChildren<MeshRenderer>(); // Utilisez le type de composant correct ici
        if(handRenderer != null)
            handRenderer.enabled = false; 
        }
        else
        {
            Debug.LogError("Épée non trouvée dans la scène!");
        }
    }

    private void ReleaseSword()
    {
        // Réactiver le modèle de la main par défaut, s'il y en a un
        var handRenderer = pose.GetComponentInChildren<MeshRenderer>(true); // Utilisez le type de composant correct ici
        if(handRenderer != null)
            handRenderer.enabled = true;

        // Détacher l'épée
        attachedSword.transform.SetParent(null);
        attachedSword = null;
    }

    private void OnDestroy()
    {
        if(grabAction != null)
            grabAction.RemoveOnChangeListener(OnGrabActionChange, pose.inputSource);
    }
}