using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HelthBar : MonoBehaviour
{
    private Slider _healthBar;

    private void Update()
    {
        _healthBar = GetComponent<Slider>();
    }

    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        _healthBar.maxValue = maxHealth;
        _healthBar.minValue = 0;
        _healthBar.value = currentHealth;
    }
}
