using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsVisuals : MonoBehaviour
{
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private Image staminaImage;
    [SerializeField]
    private Image xpImage;
    [SerializeField]
    private Text levelText;


    [SerializeField]
    GameObject gameOverScreen;

    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();    
        if(playerStats) {
            playerStats.HpChanged += OnHpChanged;
            playerStats.StaminaChanged += OnStaminaChanged;
            playerStats.XpChanged += OnXpChanged;
            playerStats.PlayerDied += ShowDeathVisuals;
        }
    }

    private void OnHpChanged() {
        healthImage.fillAmount = playerStats.Hp / (float)playerStats.MaxHp;
    }
    private void OnStaminaChanged() {
        staminaImage.fillAmount = playerStats.Stamina / 100f;
    }
    private void OnXpChanged() {
        xpImage.fillAmount = playerStats.Xp / (float)playerStats.NeededForNextLevel;
        levelText.text = playerStats.Level.ToString();
    }

    private void OnDestroy() {
        playerStats.HpChanged -= OnHpChanged;
        playerStats.StaminaChanged -= OnStaminaChanged;
        playerStats.XpChanged -= OnXpChanged;
        playerStats.PlayerDied -= ShowDeathVisuals;
    }

    private void ShowDeathVisuals() {
        gameOverScreen.SetActive(true);
    }
}
