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

    private float ChangeHelth(float value)
    {
        _health = value;
        _health = Mathf.Clamp(_health, 0, 100);
        OnHealthChange?.Invoke(_health);
        return _health;
    }

    public void TakeDamage(float damageValue)
    {
        float targetHealth = _health - damageValue;
        ChangeHelth(targetHealth);
        OnTakeDamage?.Invoke(targetHealth);
    }

    public void Heal(float damageValue)
    {
        float targetHealth = _health + damageValue;
        ChangeHelth(targetHealth);
        OnHealed?.Invoke(targetHealth);
    }
}
