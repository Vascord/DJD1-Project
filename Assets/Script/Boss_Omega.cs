using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Omega : MonoBehaviour
{
    [SerializeField] string    playerTag = "";
    [SerializeField] Transform player;
    [SerializeField] Transform gooplauncher_1; 
    [SerializeField] Transform gooplauncher_2;
    [SerializeField] Transform gooplauncher_3;
    [SerializeField] Transform goop; 
    [SerializeField] Transform enemy_1; 
    [SerializeField] Transform enemy_2; 

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

        if(taks == 0)
        {
            cooldown = Time.time;
            luck = Random.Range(1,3);
            taks = 1;
        }
        else if(Time.time - cooldown <= 2)
        {
            
        }
        else
        {
            if(luck == 1)
            {
                if(toks == 0)
                {
                    cooldown_2 = Time.time;
                    toks = 1;
                }
                if((tiks < 3) && (Time.time - cooldown_2 >= 3f))
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
            if(luck == 2)
            {
                if(tiks == 0)
                {
                    cooldown_2 = Time.time;
                    tiks = 1;
                }
                if((toks < 3) && (Time.time - cooldown_2 >= 5f))
                {
                    Quaternion rotation = transform.rotation;

                    Instantiate(goop, gooplauncher_1.transform.position, rotation);

                    Instantiate(goop, gooplauncher_2.transform.position, rotation);

                    Instantiate(goop, gooplauncher_3.transform.position, rotation);

                    Instantiate(goop, gooplauncher_1.transform.position, rotation);


                    tiks = 0;
                    toks += 1;
                }
                if((toks == 0) && (Time.time - cooldown_2 >= 3f))
                {
                    Quaternion rotation = transform.rotation;

                    Instantiate(enemy_1, gooplauncher_1.transform.position, rotation);

                    Instantiate(enemy_2, gooplauncher_3.transform.position, rotation);

                    tiks = 0;

                    toks += 1;
                }
                else if(toks == 3)
                {
                    luck = 0;
                    toks = 0;
                    taks = 0;
                }


            }
        }
    }
        
}
