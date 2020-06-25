using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class SavePointGrab : MonoBehaviour
{
    [Tag]
    new public string savepoint;
    public GameObject Player;
    public GameObject Weapon;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (savepoint == collision.tag)
        {
            HP player = Player.GetComponent<HP>();

            if (player)
            {
                player.HealDamage();
                Player_Management.Instance.position = gameObject.transform.position;

                SaveManagement number = collision.GetComponent<SaveManagement>();
                Player_Management.Instance.save_point = number.save_points_number;

                Shoot weapon = Weapon.GetComponent<Shoot>();

                if (weapon)
                {
                    for(int i = 0; i < weapon.ammo.Length; i++)
                    {
                        Player_Management.Instance.ammo[i] = weapon.ammo[i];
                    }
                    for(int i = 0; i < weapon.weapon.Length; i++)
                    {
                        Player_Management.Instance.weapon[i] = weapon.weapon[i];
                    }
                }
            }
        }
    }
}
