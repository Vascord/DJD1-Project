using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossfightStarts : MonoBehaviour
{
    public GameObject Player;
    public GameObject Boss;

    private void OnTriggerEnter2D()
    {
        Player_Mouvement player = Player.GetComponent<Player_Mouvement>();
        
        if(player)
        {
            player.enabled = true;
        }

        Boss_Omega boss = Boss.GetComponent<Boss_Omega>();
       
        if(boss)
        {
            boss.enabled = true;
        }
    }
}
