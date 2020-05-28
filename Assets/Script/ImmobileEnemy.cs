using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobileEnemy : MonoBehaviour
{
    [SerializeField] Transform gun = null;
    [SerializeField] Transform enemy = null;
    [SerializeField] Transform player;
    [SerializeField] float        cooldownTime = 0.5f;
    [SerializeField] float        triggerTime = 1.0f;
    [SerializeField] GameObject   bullet;

    Vector3 player_position;
    Vector3 forward;

    float distance_player;
    float timer;
    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        timer = triggerTime;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            if (cooldown <= 0.0f)
            {
                Quaternion rotation = transform.rotation;

                distance_player = Vector3.Distance((player.transform.position + new Vector3 (0,8,0)), gun.transform.position);

                if(distance_player < 200)
                {
                    player_position = ((player.transform.position + new Vector3 (0,8,0)) - gun.transform.position).normalized;

                    forward = (gun.transform.position - enemy.transform.position).normalized;

                    if(Vector3.Dot(player_position, forward) > 0.6)
                    {
                        Vector3 dir = ((player.transform.position + new Vector3 (0,8,0)) - transform.position).normalized;
                        rotation = Quaternion.LookRotation(Vector3.forward, dir);

                        Instantiate(bullet, transform.position, rotation);
                        
                    }
                    else if(Vector3.Dot(player_position, forward) < -0.6)
                    {
                        transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
                    }
                }

                cooldown = cooldownTime;

                timer = triggerTime;
            }
        }
    }
}
