using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScrollbar : MonoBehaviour
{
    public Slider playerHealthBar;
    public TextMeshProUGUI lifeText;

    private playerAttack playerController;


    public int totalCrystals = 0;
    public TextMeshProUGUI crystalText;

    void Start()
    {
        playerController = GetComponent<playerAttack>();
        playerHealthBar.maxValue = Mathf.RoundToInt(playerController.maxHealth);
        playerHealthBar.minValue = 0;
        playerHealthBar.value = playerHealthBar.maxValue;
        lifeText.text = playerHealthBar.maxValue + "%";

        if (crystalText)
        {
            UpdateCrystalUI();
        }
    }

    public void UpdatePlayerHealthBar(int amount = 0)
    {
        if (amount <= 0) return;
        
        playerHealthBar.value = amount;
        lifeText.text = amount + "%";
    }

    public void AddCrystal()
    {
        totalCrystals++;
        UpdateCrystalUI();
    }
    void UpdateCrystalUI()
    {
        crystalText.text = "" + totalCrystals;
    }

}

