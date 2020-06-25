using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Management : MonoBehaviour
{
    public float ahp;
    public Vector3 position = new Vector3(0,0,0);
    public int[] weapon = new int [] {2, 0, 0};
    public int[] ammo = new int [] {0, 0, 0};
    public int save_point;

    public static Player_Management Instance;

    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
}
