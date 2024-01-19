using UnityEngine;
using Valve.VR;

public class PauseController : MonoBehaviour
{
    public SteamVR_Action_Boolean pauseAction;
    private bool isPaused = false;

    void Start()
    {
        if (pauseAction == null)
        {
            Debug.LogError("Pause action not set!");
            return;
        }

        pauseAction.AddOnChangeListener(OnPausePressed, SteamVR_Input_Sources.Any);
    }

    private void OnPausePressed(SteamVR_Action_Boolean action, SteamVR_Input_Sources source, bool newState)
    {
        if (newState)
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
