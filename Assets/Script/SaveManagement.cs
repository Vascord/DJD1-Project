using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagement : MonoBehaviour
{
    public int save_points_number = 0;

    void Awake ()   
    {
        if(Player_Management.Instance.save_point == save_points_number)
        {
            Destroy(gameObject);
        }
    }
}
