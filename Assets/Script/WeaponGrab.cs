using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class WeaponGrab : MonoBehaviour
{
    [Tag]
    new public string tag;
    public GameObject LayingWeapon;
    public GameObject newGun;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == collision.tag)
        {
            Destroy(LayingWeapon);

            Shoot weapon = newGun.GetComponent<Shoot>();

            if (weapon)
            {
                weapon.NewWeapon(1);
            }
        }
    }
}
