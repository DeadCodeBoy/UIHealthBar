using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _health;
    private float _value = 10;

    public static Action<float, float> OnHealthChange;
    public static Action<float, float> OnTakeDamage;
    public static Action<float, float> OnHealed;

    public float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;

            if (_health <= 0)
            {
                _health = 0;
            }

            OnHealthChange?.Invoke(_maxHealth, _health);
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
        OnTakeDamage?.Invoke(currentHealth, targetHealth);
    }

    private void Heal(float damageValue)
    {
        float currentHealth = Health;
        float targetHealth = currentHealth + damageValue;
        OnHealed?.Invoke(currentHealth, targetHealth);
    }

    public void OnButtonHpAddClick()
    {
        Heal(_value);
    }

    public void OnButtonHitClick()
    {
        TakeDamage(_value);
    }
}
