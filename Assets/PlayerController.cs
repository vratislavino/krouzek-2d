using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public float jumpForce = 100;

    // Start is called before the first frame update
    void Start()
    {   
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        rigid.AddForce(Vector2.right * input * speed);

        var jump = Input.GetButtonDown("Jump");
        if(jump) {
            rigid.AddForce(Vector2.up * jumpForce);
        }
    }
}
