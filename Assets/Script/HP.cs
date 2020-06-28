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
    public GameObject Pew;
    Animator anim;

    float timer = 0.0f;
    float cooldown = 0.0f;
    int tik = 0;

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

        if(gameObject.name == "Barrier")
        {
            if((Time.time - cooldown >= 5) && (tik == 1))
            {
                gameObject.transform.position = new Vector3 (2083.3f, -1648.6f, 0);
                tik = 0;
            }
        }
        if((gameObject.layer == 10) && (hp <= 0))
        {
            if(tik == 0)
            {
                cooldown = Time.time;
                tik = 1;
                anim.SetTrigger("Pdeath");
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
                Player_Mouvement boy = gameObject.GetComponent<Player_Mouvement>();

                if(boy)
                {
                    boy.enabled = false ;
                }

                Shoot pew = Pew.GetComponent<Shoot>();

                if(pew)
                {
                    pew.enabled = false;
                }
            }
            else if((Time.time - cooldown >= 3) && (ahp > 0))
            {
                BackInTime();
            }
            else if((Time.time - cooldown >= 3) && (ahp <= 0))
            {
                BackToMainMenu();
            }
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
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

        if (gameObject.layer == 10)
        {
            isInvulnerable = true;

            if(damage > 0)
            {
                anim.SetTrigger("OnHit");
                FindObjectOfType<AudioManager>().Play("playerdamaged");
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
        Boss_Omega coiso = gameObject.GetComponent<Boss_Omega>();
        if((coiso) && (hp <= 0))
        {
            Victory.SetActive(true);
        }

        if ((hp <= 0) && (gameObject.layer != 10))
        {
            if(gameObject.name == "Barrier")
            {
                hp = 200;
                cooldown = Time.time;
                tik = 1;
                gameObject.transform.position = new Vector3 (-30000f, -30000f, 0);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("mimicDed");
                Destroy(gameObject);
            }
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Player_Management.Instance.ahp = ahp;
    }
}
