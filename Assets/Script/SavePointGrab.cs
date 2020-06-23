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

                Shoot weapon = Weapon.GetComponent<Shoot>();

                if (weapon)
                {
                    Player_Management.Instance.ammo = weapon.ammo;
                    Player_Management.Instance.weapon = weapon.weapon;
                }
            }
        }
    }
}
