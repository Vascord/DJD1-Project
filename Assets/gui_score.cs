using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class gui_score : MonoBehaviour
{

    public Text gui_hp;
    public hp_system Player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gui_hp.text = Player.hp.ToString();
    }
}
