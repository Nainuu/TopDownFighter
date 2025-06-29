using System;
using System.Data;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

[Serializable]
public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
