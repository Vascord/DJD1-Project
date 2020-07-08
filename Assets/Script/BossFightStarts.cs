using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStarts : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;
    public GameObject Gun;

    public void Cutscene()
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

        Boss_Alpha boss = Boss.GetComponent<Boss_Alpha>();

        if(boss)
        {
            boss.enabled = true;
        }
    }
}
