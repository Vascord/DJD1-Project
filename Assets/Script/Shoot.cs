using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;

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
    public GameObject   macbullet;
    public GameObject   handgun;
    public GameObject   shotgun;
    public GameObject   mac10;

    public Text ammoText;
    public int[] weapon = new int [] {2, 0, 0};

    public int[] ammo = new int [] {0, 0, 0};

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
        for(int i = 0; i < ammo.Length; i++)
        {
            ammo[i] = Player_Management.Instance.ammo[i];
        }
        for(int i = 0; i < weapon.Length; i++)
        {
            weapon[i] = Player_Management.Instance.weapon[i];
        }
    }

    void Update()
    {
        if(weapon[0] == 2)
        {
            cooldownTime = 0.5f;
            triggerTime = 1.0f;
            CooldownTiming(cooldownTime, triggerTime);
            handgun.SetActive(true);
            shotgun.SetActive(false);
            mac10.SetActive(false);
            ammoText.text = "∞";
        }
        else if(weapon[1] == 2)
        {
            cooldownTime = 1f;
            triggerTime = 1.0f;
            CooldownTiming(cooldownTime, triggerTime);
            handgun.SetActive(false);
            shotgun.SetActive(true);
            mac10.SetActive(false);
            ammoText.text = ammo[1].ToString();
        }
        else if(weapon[2] == 2)
        {
            cooldownTime = 0.1f;
            triggerTime = 1.0f;
            CooldownTiming(cooldownTime, triggerTime);
            handgun.SetActive(false);
            shotgun.SetActive(false);
            mac10.SetActive(true);
            ammoText.text = ammo[2].ToString();
        }

        if (Input.GetButtonDown("Swap"))
        {
            bool current_weapon = false;
            int e = 0;
            for(int i = 0; i < 3; i++)
            {
                if(weapon[i] == 2) 
                {
                    current_weapon = true;
                    e = i;
                }
                else if((current_weapon == true) && (weapon[i] == 1))
                {
                    
                    weapon[i] = 2;
                    current_weapon = false;
                    weapon[e] = 1;
                    FindObjectOfType<AudioManager>().Play("gunswap");
                    break;
                }
            }

            if(current_weapon == true)
            {
                for(int i = 0; i < 3; i++)
                {
                    if(weapon[i] == 1)
                    {
                        weapon[i] = 2;
                        current_weapon = false;
                        weapon[e] = 1;
                        FindObjectOfType<AudioManager>().Play("gunswap");
                        break;
                    }
                }
            }
            if (current_weapon == true)
            {
                weapon[0] = 2;
            }

        }
    }

    public void NewWeapon(int number)
    {
        if(weapon[number] == 0)
        {
            weapon[number] = 1;
        }

        if(number == 1)
        {
            ammo[number] = 10;
        }
        if(number == 2)
        {
            ammo[number] = 60;
        }
    }

    void CooldownTiming(float cooldownTime, float triggerTime)
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
                if (Input.GetButton(trigger))
                {
                    Fire();
                }
            }
        }
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

        if ((gameObject.tag == "Player") && (weapon[0] == 2))
        {
            FindObjectOfType<AudioManager>().Play("pistol");
            Instantiate(bullet, transform.position, rotation);
        }

        if((gameObject.tag == "Player") && (weapon[1] == 2))
        {
            FindObjectOfType<AudioManager>().Play("shotgun");
            if (rotation[0] > 0)
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

            ammo[1] -= 1;

            if(ammo[1] == 0)
            {
                weapon[1] = 0;
                weapon[0] = 2;
            }
        }

        if((gameObject.tag == "Player") && (weapon[2] == 2))
        {
            FindObjectOfType<AudioManager>().Play("mac10");
            if (rotation[0] > 0)
            {
                rotation = Quaternion.LookRotation(Vector3.forward, new Vector3 (-1,Random.Range(-0.2f,0.2f),0));

                Instantiate(macbullet, transform.position, rotation);
            }
            else
            {   
                rotation = Quaternion.LookRotation(Vector3.forward, new Vector3 (1,Random.Range(-0.2f,0.2f),0));

                Instantiate(macbullet, transform.position, rotation); 
            }
            ammo[2] -= 1;

            if(ammo[2] == 0)
            {
                weapon[2] = 0;
                weapon[0] = 2;
            }
        }

        cooldown = cooldownTime;
    }

}