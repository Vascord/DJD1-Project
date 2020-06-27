using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCinematic : MonoBehaviour
{
    public GameObject wall_f;
    public GameObject wall_g;
    public GameObject camera;
    public GameObject truecamera;
    public GameObject Player;
    public GameObject platform;

    public void Cutscene()
    {
        wall_f.SetActive(true);
        wall_g.SetActive(true);
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
