using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBase : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private bool _isDead = false;

    public UnityEvent OnHealthMax;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        SetMaxHealth();
    }

    public void SetMaxHealth()
    {
        _currentHealth = MaxHealth;
        OnHealthMax?.Invoke();
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnTakeDamage?.Invoke();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _isDead = true;
        OnDie?.Invoke();
    }
}