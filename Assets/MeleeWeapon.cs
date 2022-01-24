using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{

    public override void Attack() {
        if (currentCooldown > 0)
            return;

        var hit = Physics2D.Raycast(transform.position, Vector2.right, 3f, contactFilter.layerMask);
        if(hit.collider) {
            Debug.Log(hit.collider);
            Destroy(hit.collider.gameObject);
        }

        currentCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;        
    }
}
