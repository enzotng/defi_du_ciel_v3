using UnityEngine;

public class EnemyDefeat : MonoBehaviour
{
    public Material defeatedSkyboxMaterial;
    public GameObject wall;

    public void OnEnemyDefeated()
    {
        RenderSettings.skybox = defeatedSkyboxMaterial;
        wall.SetActive(false);
    }

    void DefeatEnemy()
    {
        OnEnemyDefeated();
    }
}
