using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Slider healthBar; // Pour la barre de vie
    public Image smallSpellIndicator; // Indicateur pour les petits sorts
    public Image largeSpellIndicator; // Indicateur pour les gros sorts
    public Text objectiveText; // Texte pour l'objectif

    // Variables pour gérer l'état des sorts (exemple)
    private bool isSmallSpellReady = true;
    private bool isLargeSpellReady = true;

    // Autres variables nécessaires (par exemple, pour la santé)
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Initialisation des variables
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        UpdateSpellIndicators();
    }

    void Update()
    {
        // Mettez à jour le HUD ici, si nécessaire
    }

    // Fonction pour mettre à jour la barre de vie
    public void UpdateHealth(int health)
    {
        currentHealth = health;
        healthBar.value = currentHealth;
    }

    // Fonction pour mettre à jour les indicateurs de sort
    public void UpdateSpellIndicators()
    {
        smallSpellIndicator.enabled = isSmallSpellReady;
        largeSpellIndicator.enabled = isLargeSpellReady;
    }

    // Fonctions pour gérer les états des sorts
    public void SetSmallSpellReady(bool isReady)
    {
        isSmallSpellReady = isReady;
        UpdateSpellIndicators();
    }

    public void SetLargeSpellReady(bool isReady)
    {
        isLargeSpellReady = isReady;
        UpdateSpellIndicators();
    }

    // Fonction pour mettre à jour l'objectif
    public void UpdateObjective(string objective)
    {
        objectiveText.text = objective;
    }
}
