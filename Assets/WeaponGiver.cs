using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiver : MonoBehaviour
{
    public string weapon = "Pistol";

    private void OnTriggerEnter2D(Collider2D collision) {
        var shooting = collision.gameObject.GetComponent<PlayerShooting>();
        if(shooting) {
            shooting.AddWeapon(weapon);
            Destroy(gameObject);
        }
    }
}
