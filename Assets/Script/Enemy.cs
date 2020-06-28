using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float     moveSpeed = 100.0f;
    [SerializeField] Transform groundDetector = null;
    [SerializeField] Transform wallDetector = null;
    [SerializeField] Transform enemyDetector = null;
    [SerializeField] float     detectionRadius = 3.0f;
    [SerializeField] float     enemydetectionRadius = 1.0f;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] GameObject player;

    Rigidbody2D rigidBody;

    Vector3 player_position;
    Vector3 forward;

    float distance_player;
    float view;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(moveSpeed, 0.0f);
        player = GameObject.Find("Player");
    }



    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = rigidBody.velocity;

        bool alreadyTurned = false;

        if ((groundDetector) && (Mathf.Abs(currentVelocity.y) < 0.1f))
        {
            Collider2D groundCollision = Physics2D.OverlapCircle(groundDetector.position, detectionRadius, groundLayers);

            bool onGround = groundCollision != null;

            if (!onGround)
            {
                TurnBack();
                alreadyTurned = true;
            }
        }

        if ((wallDetector) && (Mathf.Abs(currentVelocity.y) < 0.1f) && (!alreadyTurned))
        {
            Collider2D wallCollision = Physics2D.OverlapCircle(wallDetector.position, detectionRadius, groundLayers);

            bool onWall = wallCollision != null;

            if (onWall)
            {
                TurnBack();
            }

        }

        if ((enemyDetector) && (Mathf.Abs(currentVelocity.y) < 0.1f))
        {
            Collider2D enemyCollision = Physics2D.OverlapCircle(enemyDetector.position, enemydetectionRadius, enemyLayers);

            bool onEnemy = enemyCollision != null;

            if (onEnemy)
            {
                TurnBack();
            }

        }
        
        distance_player = Vector3.Distance ((player.transform.position + new Vector3 (0,8,0)), wallDetector.transform.position);

        if(distance_player < 150)
        {
            player_position = (wallDetector.transform.position - (player.transform.position + new Vector3 (0,8,0))).normalized;

            forward = (wallDetector.transform.position - enemyDetector.transform.position).normalized;

            if(Vector3.Dot(player_position, forward) > 0.9)
            {
                currentVelocity.x = transform.right.x * 150.0f;

                rigidBody.velocity = currentVelocity;
            }
            else
            {
                currentVelocity.x = transform.right.x * moveSpeed;

                rigidBody.velocity = currentVelocity;
            }
        }
        else
        {
            currentVelocity.x = transform.right.x * moveSpeed;

            rigidBody.velocity = currentVelocity;
        }

    }

    void TurnBack()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
    }
}
