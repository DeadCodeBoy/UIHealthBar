using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HelthBar : MonoBehaviour
{
    private Slider _healthBarSlider;
 
    private void Start()
    {
        _healthBarSlider = GetComponent<Slider>();
    }
    
    private void OnEnable()
    {
        Player.OnHealthChange += UpdateHealthbar;
        Player.OnTakeDamage += ChangeSlide;
        Player.OnHealed += ChangeSlide;
    }

    private void OnDisable()
    {
        Player.OnHealthChange -= UpdateHealthbar;
        Player.OnTakeDamage -= ChangeSlide;
        Player.OnHealed += ChangeSlide;
    }

    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        _healthBarSlider.maxValue = maxHealth;
        _healthBarSlider.minValue = 0;
        _healthBarSlider.value = currentHealth;
    }

    public void ChangeSlide(float currentHealth, float targetHealth)
    {
        StartCoroutine(SmoothSlide(currentHealth, targetHealth));
    }

    private IEnumerator SmoothSlide(float startValue, float endValue)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            _healthBarSlider.value = currentValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _healthBarSlider.value = endValue;
    }
}
