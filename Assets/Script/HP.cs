﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float hp = 150;
    public float ahp = 50;

    float timer = 0.0f;

    public bool isInvulnerable
    {
        get
        {
            return timer > 0;
        }
        set
        {
            if (value) timer = 0.5f;
            else timer = 0;
        }
    }

    private void Update()
    {
        if(timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
    }

    public void DealDamage(float damage, float Adamage)
    {
        if(isInvulnerable) return;
        
        if(hp <= 0) return;

        hp = hp - damage;

        ahp = ahp - Adamage;

        if (gameObject.layer == 10)
        {
            if(ahp <= 0)
            {
                Destroy(gameObject);
            }
            else if (hp <= 0)
            {
                gameObject.transform.position = new Vector3 (-141,-30,0);
                hp = 150;
            }
            else
            {
                isInvulnerable = true;
            }
        }
        else if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
