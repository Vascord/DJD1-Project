using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mouvement : MonoBehaviour
{
    public float maxSpeed = 100.0f;
    public float jumpSpeed = 200.0f;
    public float jumpMaxTime = 0.1f;

    public Transform groundCheck;
    public LayerMask groundLayers; 

    float jumpTime;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");

        Vector2 currentVelocity = rb.velocity;

        currentVelocity = new Vector2(maxSpeed * hAxis, currentVelocity.y);

        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 5, groundLayers);
        
        bool onGround = groundCollision != null;

        if ((Input.GetButtonDown("Jump")) && (onGround))
        {
            currentVelocity.y = jumpSpeed;
            rb.gravityScale = 0.0f;

            jumpTime = Time.time;
        }
        else if ((Input.GetButton("Jump")) && ((Time.time - jumpTime) < jumpMaxTime))
        {
        }
        else
        {
            rb.gravityScale = 3.0f;
        }

        rb.velocity = currentVelocity;
    }
}