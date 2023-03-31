using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
  
    private float _health;
   
    public static Action<float> OnHealthChange;
    public static Action<float> OnTakeDamage;
    public static Action<float> OnHealed;

    private void Start()
    {
        _health = _maxHealth;
    }

    public float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;

            if (_maxHealth > 100)
            {
                _health = 100;
            }

            if (_health <= 0)
            {
                _health = 0;
                Debug.Log("you die");
            }
         }
    }

    private void ChangeHelth(float value)
    {
        Health = value;
        
        if (Health<0)
        {
            Health = 0;
        }

        if (Health>100)
        {
            Health = _maxHealth;
        }
        OnHealthChange?.Invoke(Health);
    }

    public void TakeDamage(float damageValue)
    {
        float targetHealth = Health - damageValue;
        ChangeHelth(targetHealth);
        OnTakeDamage?.Invoke( targetHealth);
    }

    public void Heal(float damageValue)
    {
        float targetHealth = Health + damageValue;
        ChangeHelth(targetHealth);
        OnHealed?.Invoke( targetHealth);
    }
}
