using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        var enemy = collision.collider.GetComponent<JumpingEnemy>();
        if(enemy) {
            Destroy(enemy.gameObject);
        }
        Destroy(gameObject);
    }
}
