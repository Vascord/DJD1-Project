using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Boss_Alpha : MonoBehaviour
{
    [SerializeField] string    playerTag = "";
    [SerializeField] Transform groundDetector = null;
    [SerializeField] LayerMask groundLayers;
    [SerializeField] Transform player; 
    [SerializeField] Transform gun; 
    [SerializeField] Transform bullet; 
    [SerializeField] Transform gooplauncher_1; 
    [SerializeField] Transform gooplauncher_2;
    [SerializeField] Transform gooplauncher_3;
    [SerializeField] Transform goop; 

    Rigidbody2D rigidBody;
    Animator anim;

    int luck;
    int rng;
    float cooldown;
    float cooldown_2;
    float cooldown_3;
    float distance;
    float distance_gun;
    bool right;
    bool left;
    int tiks;
    int toks;
    int taks;
    bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        luck = 0;
        cooldown = 0.0f;
        cooldown_2 = 0.0f;
        cooldown_3 = 0.0f;
        tiks = 0;
        toks = 0;
        right = false;
        left = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentVelocity = rigidBody.velocity;

        Collider2D groundCollision = Physics2D.OverlapCircle(groundDetector.position, 4, groundLayers);

        onGround = groundCollision != null;

        if(taks == 0)
        {
            cooldown = Time.time;
            luck = Random.Range(1,4);
            taks = 1;
        }
        else if(Time.time - cooldown <= 2)
        {
            
        }
        else
        {
            if(luck == 1)
            {

                if(tiks == 0)
                {
                    cooldown_3 = Time.time;
                    distance = player.transform.position[0] - gameObject.transform.position[0];
                    tiks = 1;
                }

                else if(Time.time - cooldown_3 <= 0.1f)
                {
                    currentVelocity.y = 500;
                    rigidBody.gravityScale = 0.0f;
                    if((distance > 30) && (tiks == 1))
                    {
                        if(left == true)
                        {
                            transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
                            left = false;
                        }
                        currentVelocity.x = distance * 1.7f;
                        right = true;
                        tiks = 2;
                    }
                    else if((distance < -30) && (tiks == 1))
                    {
                        if(right == true)
                        {
                            transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
                            right = false;
                        }
                        currentVelocity.x = distance * 1.7f;
                        left = true;
                        tiks = 2;
                    }

                    if(right == true)
                    {
                        currentVelocity.x = distance * 1.7f;
                    }
                    else if(left == true)
                    {
                        currentVelocity.x = distance * 1.7f;
                    }
                }
                else
                {
                    rigidBody.gravityScale = 11.0f;

                    if(onGround)
                    {
                        if(tiks == 2)
                        {
                            cooldown_2 = Time.time;
                            tiks = 3;
                        }

                        if(Time.time - cooldown_2 <= 0.7f)
                        {

                        }
                        else
                        {
                            toks += 1;
                            tiks = 0;
                            if(toks == 5)
                            {
                                luck = 0;
                                taks = 0;
                                toks = 0;
                                distance = player.transform.position[0] - gameObject.transform.position[0];
                                if(((distance < -30) && (right == true)) || ((distance > 30) && (left == true)))
                                {
                                    transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
                                }
                                right = false;
                                left = false;
                            }
                        }
                    }
                    else
                    {
                        if(right == true)
                        {
                            currentVelocity.x = distance * 1.3f;
                        }
                        if(left == true)
                        {
                            currentVelocity.x = distance * 1.3f;
                        }
                    }
                }
            }
        }

        if(luck == 2)
        {
            if(toks == 0)
            {
                cooldown_2 = Time.time;
                toks = 1;
            }
            if((tiks < 4) && (Time.time - cooldown_2 >= 2.5f))
            {
                Quaternion rotation = transform.rotation;
                
                GameObject[] targets = GameObject.FindGameObjectsWithTag(playerTag);
                
                if (targets.Length > 0)
                {
                    GameObject  player = targets[0];
                    float       dist = (transform.position - player.transform.position).magnitude;

                    for (int i = 1; i < targets.Length; i++)
                    {
                        float tmp = (transform.position - targets[i].transform.position).magnitude;
                        if (tmp < dist)
                        {
                            player = targets[i];
                            dist = tmp;
                        }
                    }

                    Vector3 dir = (player.transform.position - transform.position).normalized;

                    rng = Random.Range(1,3);
                    if(rng == 1)
                    {
                        rotation = Quaternion.LookRotation(Vector3.forward, dir + new Vector3(0,0.3f,0));

                        Instantiate(bullet, gun.transform.position, rotation);

                        rotation = Quaternion.LookRotation(Vector3.forward, dir);

                        Instantiate(bullet, gun.transform.position, rotation);

                        rotation = Quaternion.LookRotation(Vector3.forward, dir + new Vector3(0,-0.3f,0));

                        Instantiate(bullet, gun.transform.position, rotation);
                    }
                    else if(rng == 2)
                    {
                        rotation = Quaternion.LookRotation(Vector3.forward, dir + new Vector3(0,0.4f,0));

                        Instantiate(bullet, gun.transform.position, rotation);

                        rotation = Quaternion.LookRotation(Vector3.forward, dir + new Vector3(0,0.2f,0));

                        Instantiate(bullet, gun.transform.position, rotation);

                        rotation = Quaternion.LookRotation(Vector3.forward, dir + new Vector3(0,-0.2f,0));

                        Instantiate(bullet, gun.transform.position, rotation);

                        rotation = Quaternion.LookRotation(Vector3.forward, dir + new Vector3(0,-0.4f,0));

                        Instantiate(bullet, gun.transform.position, rotation);
                    }

                    tiks += 1;
                    toks = 0;
                }
            }

            else if(tiks == 4)
            {
                luck = 0;
                tiks = 0;
                taks = 0;
            }
        }

        if(luck == 3)
        {
            if(toks == 0)
            {
                cooldown_2 = Time.time;
                toks = 1;
            }
            if((tiks < 3) && (Time.time - cooldown_2 >= 4f))
            {
                Quaternion rotation = transform.rotation;

                Instantiate(goop, gooplauncher_1.transform.position, rotation);

                Instantiate(goop, gooplauncher_2.transform.position, rotation);

                Instantiate(goop, gooplauncher_3.transform.position, rotation);

                Instantiate(goop, gooplauncher_1.transform.position, rotation);

                Instantiate(goop, gooplauncher_2.transform.position, rotation);

                Instantiate(goop, gooplauncher_3.transform.position, rotation);

                Instantiate(goop, gooplauncher_1.transform.position, rotation);

                Instantiate(goop, gooplauncher_2.transform.position, rotation);

                Instantiate(goop, gooplauncher_3.transform.position, rotation);

                tiks += 1;
                toks = 0;
            }

            else if(tiks == 3)
            {
                luck = 0;
                tiks = 0;
                taks = 0;
            }
        }

        rigidBody.velocity = currentVelocity;
    }
}
