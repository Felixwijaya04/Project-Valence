using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarArmor : MonoBehaviour
{
    public Slider slider;

    public void setArmor(int armor)
    {
        slider.maxValue = armor;
    }

    public void setCurrentarmor(int currentarmor)
    {
        slider.value = currentarmor;
    }
}
