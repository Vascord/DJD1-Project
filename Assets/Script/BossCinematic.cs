using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCinematic : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject camera;
    public GameObject truecamera;
    public GameObject Player;
    public GameObject platform;

    public void Cutscene()
    {
        wall1.SetActive(true);
        wall2.SetActive(true);
        truecamera.SetActive(false);
        camera.SetActive(true);
        Destroy(platform);

        Player_Mouvement player = Player.GetComponent<Player_Mouvement>();

        if(player)
        {
            player.Stop();
            player.enabled = false;
        }
    }
}
