using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Shoot : MonoBehaviour
{
    public enum ShootMode { Trigger, Auto };
    public ShootMode    mode = ShootMode.Auto;
    [ShowIf("IsTrigger")]
    public string       trigger = "Fire1";
    [ShowIf("IsTrigger")]
    public float        cooldownTime = 0.5f;
    [ShowIf("IsAuto")]
    public float        triggerTime = 1.0f;

    public bool         autoAim = false;
    [ShowIf("autoAim"),Tag]
    public string       targetTag = "";
    public GameObject   bullet;
    public GameObject   shotgunbullet;
    public int[] weapon = new int [] {2, 0};

    bool IsTrigger()
    {
        return mode == ShootMode.Trigger;
    }

    bool IsAuto()
    {
        return mode == ShootMode.Auto;
    }
    
    float timer;
    float cooldown;

    void Start()
    {
        timer = triggerTime;
        cooldown = 0.0f;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (mode == ShootMode.Auto)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                if (cooldown <= 0.0f)
                {
                    Fire();
                    timer = triggerTime;
                }
            }
        }
        else
        {
            if (cooldown <= 0.0f)
            {
                if (Input.GetButtonDown(trigger))
                {
                    Fire();
                }
            }
        }

        if (Input.GetButtonDown("Swap"))
        {
            bool next = false;
            for(int i = 0; i < 2; i++)
            {
                if(weapon[i] == 1)
                {
                    weapon[i] = 2;
                    next = true;
                }
                if((weapon[i] == 2) && (next == false))
                {
                    weapon[i] = 1;
                }
                next = false;
            }
            
            int e = 0;

            for(int i = 0; i < 2; i++)
            {
                if(weapon[i] == 2)
                {
                    break;
                }

                e++;

                if(i+1 == e)
                {
                    weapon[0] = 2;
                }
            }
            Debug.Log(weapon[1]);
        }
    }

    public void NewWeapon(int number)
    {
        weapon[number] = 1;
    }

    void Fire()
    {
        Quaternion rotation = transform.rotation;

        if (autoAim)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
            
            if (targets.Length > 0)
            {
                GameObject  target = targets[0];
                float       dist = (transform.position - target.transform.position).magnitude;

                for (int i = 1; i < targets.Length; i++)
                {
                    float tmp = (transform.position - targets[i].transform.position).magnitude;
                    if (tmp < dist)
                    {
                        target = targets[i];
                        dist = tmp;
                    }
                }

                Vector3 dir = (target.transform.position - transform.position).normalized;
                rotation = Quaternion.LookRotation(Vector3.forward, dir);

                Instantiate(bullet, transform.position, rotation);
            }
        }

        if((gameObject.tag == "Player") && (weapon[1] == 2))
        {
            if(rotation[0] > 0)
            {
                for(float i = -0.3f; i < 0.31; i += 0.1f)
                {
                    rotation = Quaternion.LookRotation(Vector3.forward, new Vector3 (-1,i,0));

                    Instantiate(shotgunbullet, transform.position, rotation);
                }
            }
            else
            {
                for(float i = -0.3f; i < 0.31; i += 0.1f)
                {
                    rotation = Quaternion.LookRotation(Vector3.forward, new Vector3 (1,i,0));

                    Instantiate(shotgunbullet, transform.position, rotation);
                }
            }
        }

        else if ((gameObject.tag == "Player") && (weapon[0] == 2))
        {
            Instantiate(bullet, transform.position, rotation);
        }

        cooldown = cooldownTime;
    }

}