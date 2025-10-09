using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderLimitation : MonoBehaviour
{

    Slider slider;

    float currentValue;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(ListenerMethod);
        currentValue = slider.value;
    }


    public void ListenerMethod(float value)
    {
        if (value < currentValue)
            slider.value = currentValue;
        else
            currentValue = value;
    }
}
