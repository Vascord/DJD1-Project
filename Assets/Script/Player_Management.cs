using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Management : MonoBehaviour
{
    public float ahp;
    public Vector3 position = new Vector3(0,0,0);

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

    void Start()
    {
        ahp = 50;
    }   
}
