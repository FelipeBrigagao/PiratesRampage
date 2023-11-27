using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class HealthBase : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private bool _isDead = false;
    private bool _canLoseHealth = true;

    public UnityEvent OnHealthMax;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnDie;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    public void Init()
    {
        SetMaxHealth();
        EnableLoseHealth();
    }

    public void SetMaxHealth()
    {
        _currentHealth = MaxHealth;
        OnHealthMax?.Invoke();
    }
    
    public void TakeDamage(int damage)
    {
        if (_isDead || !_canLoseHealth) return;
        
        _currentHealth -= damage;
        OnTakeDamage?.Invoke();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void InstantDie()
    {
        if (_isDead || !_canLoseHealth) return;
        TakeDamage(_maxHealth);
    }

    public void Die()
    {
        if (_isDead || !_canLoseHealth) return;
     
        _isDead = true;
        OnDie?.Invoke();
    }

    public void EnableLoseHealth()
    {
        _canLoseHealth = true;
    }
    
    public void DisableLoseHealth()
    {
        _canLoseHealth = false;
    }
}