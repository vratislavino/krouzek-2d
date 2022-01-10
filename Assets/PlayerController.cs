using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public float jumpForce = 100;

    bool isGrounded = true;
    public List<Transform> GroundingPoints;
    public float maxSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {   
        rigid = GetComponent<Rigidbody2D>();
    }

    private void UpdateIsGrounded() {

        /*Debug.DrawLine(
            GroundingPoint.position, 
            GroundingPoint.position + (Vector3.down*0.3f), 
            Color.red, 
            1f);*/

        isGrounded = GroundingPoints.Any(point => {
            return Physics2D.Raycast(point.position, Vector2.down, 0.3f).collider != null; ;
        });
    }

    void ClampHorizontalVelocity() {
        var vel = rigid.velocity;
        if(vel.x < -maxSpeed) {
            vel.x = -maxSpeed;
        } else if (vel.x > maxSpeed) {
            vel.x = maxSpeed;
        }
        rigid.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIsGrounded();


        var input = Input.GetAxis("Horizontal");
        rigid.AddForce(Vector2.right * input * speed);

        if (isGrounded) {
            var jump = Input.GetButtonDown("Jump");
            if (jump) {
                rigid.AddForce(Vector2.up * jumpForce);
            }
        }

        ClampHorizontalVelocity();
    }
}
