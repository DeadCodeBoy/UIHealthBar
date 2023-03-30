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
        Player.OnHealed -= ChangeSlide;
    }

    public void UpdateHealthbar( float currentHealth)
    {
       _healthBarSlider.value = currentHealth;
    }

    public void ChangeSlide(float targetHealth)
    {
        StartCoroutine(SmoothSlide(targetHealth));
    }

    private IEnumerator SmoothSlide(float endValue)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;
        float startValue = _healthBarSlider.value;

        while (startValue != endValue)
        {
            float currentValue = Mathf.MoveTowards(startValue, endValue, elapsedTime / duration ); 
            _healthBarSlider.value = currentValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _healthBarSlider.value = endValue;
    }
}
