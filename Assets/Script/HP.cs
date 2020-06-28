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
    public GameObject Gameover;
    public GameObject Victory;
    public GameObject Player_management;
    public GameObject wall_f;
    public GameObject wall_g;
    public GameObject camera;
    public GameObject truecamera;

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
            healthbar.SetHealth(hp);
            ahealthbar.SetAHealth(ahp);
        }
    }

    public void DealDamage(float damage, float Adamage)
    {
        if(isInvulnerable) return;
        
        if(hp <= 0) return;

        hp = hp - damage;

        ahp = ahp - Adamage;
        
        if(gameObject.layer == 9 && hp >= 1)
        {
            //bool enemie gets damaged
        }

        if (gameObject.layer == 10)
        {
            isInvulnerable = true;
            FindObjectOfType<AudioManager>().Play("playerdamaged");
            if ((ahp <= 0) && (hp <= 0))
            {
                //permanent death
                BackToMainMenu();
            }
            else if (hp <= 0)
            {
                //temporary death
                BackInTime();
            }

            healthbar.SetHealth(hp);
            ahealthbar.SetAHealth(ahp);

        }

        Boss_Alpha boss = gameObject.GetComponent<Boss_Alpha>();
        if((SceneManager.GetActiveScene().name == "Level_1") && (boss) && (hp <= 0))
        {
            Victory.SetActive(true);
            Player_Management.Instance.position = new Vector3(0,0,0);
            Player_Management.Instance.save_point = 0;
        }
        else if((SceneManager.GetActiveScene().name == "Level_2") && (boss) && (hp <= 0))
        {
            wall_f.SetActive(false);
            wall_g.SetActive(false);
            truecamera.SetActive(true);
            camera.SetActive(false);
            Destroy(gameObject);
        }

        if (hp <= 0)
        {
            FindObjectOfType<AudioManager>().Play("mimicDed");
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
        Gameover.SetActive(true);
        Time.timeScale = 0f;
        Player_Management.Instance.ahp = 50;
        Player_Management.Instance.position = new Vector3 (0,0,0);
        Player_Management.Instance.weapon =  new int [] {2, 0, 0};
        Player_Management.Instance.ammo = new int [] {0, 0, 0};
        Player_Management.Instance.save_point = 0;
    }

    void BackInTime()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Player_Management.Instance.ahp = ahp;
    }
}
