using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStarts : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;

    public void Cutscene()
    {
        Player_Mouvement player = Player.GetComponent<Player_Mouvement>();

        if(player)
        {
            player.enabled = true;
        }

        Boss_Alpha boss = Boss.GetComponent<Boss_Alpha>();

        if(boss)
        {
            boss.enabled = true;
        }
    }
}
