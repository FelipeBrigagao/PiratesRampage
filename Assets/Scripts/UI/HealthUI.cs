using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    [SerializeField] private HealthBase _health;

    private void Awake()
    {
        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.minValue = 0;
    }

    public void UpdateHealthBar()
    {
        _healthSlider.value = _health.CurrentHealth;
    }
    
    
}
