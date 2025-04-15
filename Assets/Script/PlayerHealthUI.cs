using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private playerAttack player;

    private float currentHealth;
    private float maxHealth;
    public Image healthBarFill;
    

    void Start()
    {
        maxHealth = player.maxHealth;
        currentHealth = player.currentHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }
}
