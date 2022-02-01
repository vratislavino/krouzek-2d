using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Weapon
{
    public GameObject slingshotBoulder;

    public override void Attack() {
        if (currentCooldown > 0)
            return;

        // Støelba
        var boulder = Instantiate(slingshotBoulder, transform.position, Quaternion.identity);
        var rigid = boulder.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.right * 15 + Vector2.up * 15, ForceMode2D.Impulse);
        rigid.AddTorque(100);
        currentCooldown = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;        
    }
}
