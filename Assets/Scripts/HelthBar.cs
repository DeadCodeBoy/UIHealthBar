using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HelthBar : MonoBehaviour
{
    private Slider _healthBarSlider;
    private Coroutine _checkCorutine;

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

    public void UpdateHealthbar(float currentHealth)
    {
        _healthBarSlider.value = currentHealth;
    }
        
    public void ChangeSlide(float targetHealth)
    {
        if (_checkCorutine != null)
        {
            StopCoroutine(_checkCorutine);
        }

       _checkCorutine= StartCoroutine(SmoothSlide(targetHealth));
    }

    private IEnumerator SmoothSlide(float endValue)
    {
        float startValue = _healthBarSlider.value;

        while (startValue != endValue)
        {
            _healthBarSlider.value = Mathf.MoveTowards(startValue, endValue, Time.deltaTime);  
            yield return null;
        }
    }
}
