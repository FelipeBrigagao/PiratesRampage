using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Kamikaze : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _attackLayers;

    public UnityEvent OnKamikaze;

    private bool _canKamikaze;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!_canKamikaze) return;
        
        if (_attackLayers == (_attackLayers | (1 << other.gameObject.layer)))
        {
            DoKamizaze(other);
        }
    }

    private void DoKamizaze(Collision2D other)
    {
        OnKamikaze?.Invoke();
        
        if (other.gameObject.TryGetComponent<HealthBase>(out HealthBase health))
        {
            health.TakeDamage(_damage);
        }
        
    }

    public void EnableKamikaze()
    {
        _canKamikaze = true;
    }
    
    public void DisableKamikaze()
    {
        _canKamikaze = false;
    }
    
}
