using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public float hp = 150;
    public float ahp = 50;
    public UIManager healthbar;
    public UIManager ahealthbar;

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

    void Start()
    {
        if (gameObject.layer == 10)
        {
            ahp = Player_Management.Instance.ahp;
        }
        healthbar.SetHealth(hp);
        ahealthbar.SetAHealth(ahp);
    }

    public void DealDamage(float damage, float Adamage)
    {
        if(isInvulnerable) return;
        
        if(hp <= 0) return;

        hp = hp - damage;

        ahp = ahp - Adamage;

        if (gameObject.layer == 10)
        {
            isInvulnerable = true;

            if((ahp <= 0) && (hp <= 0))
            {
                BackToMainMenu();
            }
            else if (hp <= 0)
            {
                BackInTime();
            }

            healthbar.SetHealth(hp);
            ahealthbar.SetAHealth(ahp);

        }
        else if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void HealDamage()
    {
        hp = 150;
        ahp = 50;
        healthbar.SetHealth(hp);
        ahealthbar.SetAHealth(ahp);
    }

    void BackToMainMenu()
    {
        Player_Management.Instance.ahp = 50;
        SceneManager.LoadScene("GameOver");
    }

    void BackInTime()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        SceneManager.LoadScene("SampleScene");
        Player_Management.Instance.ahp = ahp;
    }
}
