using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCinematic : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject camera;
    public GameObject truecamera;

    public void Cutscene()
    {
        wall1.SetActive(true);
        wall2.SetActive(true);
        truecamera.SetActive(false);
        camera.SetActive(true);
    }
}
