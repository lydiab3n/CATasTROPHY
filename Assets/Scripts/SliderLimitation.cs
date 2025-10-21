using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class SliderLimitation : MonoBehaviour
{

    Slider slider;

    float currentValue;

    public Boolean reset=false;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(ListenerMethod);
        currentValue = slider.value;
    }


    public void ListenerMethod(float value)
    {
        if (!reset && value < currentValue)
            slider.value = currentValue;
        else
            currentValue = value;
    }
}
