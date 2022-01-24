using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bullet;

    public override void Attack() {
        if (currentCooldown > 0)
            return;

        var newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        var rigid = newBullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.right * 30, ForceMode2D.Impulse);
        currentCooldown = cooldown;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
    }
}
