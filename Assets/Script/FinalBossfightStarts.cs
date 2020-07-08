using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossfightStarts : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;
    public GameObject Gun;

    private void OnTriggerEnter2D()
    {
        Player_Mouvement player = Player.GetComponent<Player_Mouvement>();
        
        if(player)
        {
            player.Go_again();
        }

        Shoot gun = Gun.GetComponent<Shoot>();

        if(gun)
        {
            gun.enabled = true;
        }

        Boss_Omega boss = Boss.GetComponent<Boss_Omega>();
       
        if(boss)
        {
            boss.enabled = true;
        }
    }
}
