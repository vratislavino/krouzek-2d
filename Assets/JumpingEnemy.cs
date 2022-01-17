using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public float jumpForce = 700;
    public float jumpCooldown = 2f;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
        //InvokeRepeating("Jump", 0, jumpCooldown);
    }

    public IEnumerator Jump() {
        while (true) {
            rigid.AddForce(Vector2.up * jumpForce);
            yield return new WaitForSeconds(jumpCooldown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
