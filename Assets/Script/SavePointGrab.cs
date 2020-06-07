using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class SavePointGrab : MonoBehaviour
{
    [Tag]
    new public string savepoint;
    public GameObject Player;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (savepoint == collision.tag)
        {
            HP player = Player.GetComponent<HP>();

            if (player)
            {
                player.HealDamage();
            }
        }
    }
}
