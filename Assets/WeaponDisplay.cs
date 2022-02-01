using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{

    public PlayerShooting playerShooting;
    private Text weaponText;

    private void Awake() {
        weaponText = GetComponent<Text>();
        playerShooting.WeaponChanged += OnWeaponChanged;
    }

    private void OnWeaponChanged(Weapon w) {
        weaponText.text = w.gameObject.name;
    }
}
