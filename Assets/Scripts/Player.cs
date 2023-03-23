using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private HelthBar _healthBar;
    [SerializeField] private float _maxHealth;
  
    private float _health;
    
    public float Health
    {
        get 
        { 
           return _health; 
        }
       
        set
        {
            _health = value;
            
            if(_health<=0)
            {
                _health = 0;
            }
            
            _healthBar.UpdateHealthbar(_maxHealth, _health);
        }
    }

    private void Start()
    {
        Health = _maxHealth;
    }

    private void TakeDamage(float damageValue)
    {
        float currentHealth = Health;
        float targetHealth = currentHealth - damageValue;
        StartCoroutine(SmoothSlide(currentHealth, targetHealth));
    }
    
    private void Heal(float damageValue)
    {
        float currentHealth = Health;
        float targetHealth = currentHealth + damageValue;
        StartCoroutine(SmoothSlide(currentHealth, targetHealth));
    }

    public void OnButtonHpAddClick()
    {
        Heal(10);
    }

    public void OnButtonHitClick()
    {
        TakeDamage(10);
    }

    private IEnumerator SmoothSlide(float startValue, float endValue)
    {
        float elapsedTime = 0f;
        float duration = 0.5f;

        while (elapsedTime < duration)
        {
            float currentValue = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            Health = currentValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Health = endValue;
    }
}
