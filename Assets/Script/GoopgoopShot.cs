﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopgoopShot : MonoBehaviour
{
    [SerializeField] Transform groundDetector = null;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] Transform groundgoop; 

    float cooldown;
    int tik;
    int tok;
    float distance;
    bool onGround;
    float rng;

    GameObject player; 
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        cooldown = 0.0f;
        tik = 0;
        tok = 0;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = rigidBody.velocity;

        if(tik == 0)
        {
            cooldown = Time.time;
            tik = 1;
        }

        else
        {
            if(tok == 0)
            {
                distance = player.transform.position[0] - gameObject.transform.position[0];
                rng = Random.Range(-100,100);
                distance += rng;
                tok = 1;
            }
            else
            {
                rigidBody.gravityScale = 4.2f;

                currentVelocity.x = (distance);

                if(onGround)
                {
                    Quaternion rotation = transform.rotation;

                    Instantiate(groundgoop, new Vector3 (gameObject.transform.position[0], -1790, 0), rotation);

                    Destroy(gameObject);
                }
            }
        }

        rigidBody.velocity = currentVelocity;
    }
}
