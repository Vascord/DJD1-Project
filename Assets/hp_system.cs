using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_system : MonoBehaviour
{

    public int hp_max = 0;
    public int hp = 0;

    public int ahp_max = 0;
    public int ahp = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if (ahp<=0)
            {
                // ele morre e o jogo termina.
            }
            else
            {
                // ele revive em outro lugar e perde ahp
            }
        }
    }
}
