using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {
            var playerStats = collider.GetComponent<PlayerStats>();
            if(playerStats) {
                playerStats.Heal(50);
                Destroy(gameObject);
            }
        }
    }
}
