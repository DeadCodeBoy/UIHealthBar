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
            }
         }
    }

    private void Start()
    {
        _health = _maxHealth;
    }

   private void ChangeHelth(float value)
    {
        Health = value;
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
