using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStarts : MonoBehaviour
{
    public GameObject Player;

    public void Cutscene()
    {
        Player_Mouvement player = Player.GetComponent<Player_Mouvement>();

        if(player)
        {
            player.enabled = true;
        }
    }
}
