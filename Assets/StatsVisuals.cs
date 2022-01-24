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
    GameObject gameOverScreen;

    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindObjectOfType<PlayerStats>();    
        if(playerStats) {
            playerStats.HpChanged += () => {
                healthImage.fillAmount = playerStats.Hp / (float)playerStats.MaxHp;
            };
            playerStats.StaminaChanged += () => {
                staminaImage.fillAmount = playerStats.Stamina / 100f;
            };
            playerStats.PlayerDied += ShowDeathVisuals;
        }
    }
    
    private void ShowDeathVisuals() {
        gameOverScreen.SetActive(true);
    }
}
