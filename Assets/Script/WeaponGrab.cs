using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class WeaponGrab : MonoBehaviour
{
    [Tag]
    new public string shotgun_tag;
    [Tag]
    new public string macdo_tag;
    public GameObject newGun;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((macdo_tag == collision.tag) || (shotgun_tag == collision.tag))
        {
            Shoot weapon = newGun.GetComponent<Shoot>();

            if ((weapon) && (macdo_tag == collision.tag))
            {
                weapon.NewWeapon(2);
            }

            else if ((weapon) && (shotgun_tag == collision.tag))
            {
                weapon.NewWeapon(1);
            }
        }
    }
}
