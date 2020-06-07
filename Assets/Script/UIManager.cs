using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(float hp)
    {
        slider.value = hp;
    }

    public void SetAHealth(float ahp)
    {
        slider.value = ahp;
    }
}
