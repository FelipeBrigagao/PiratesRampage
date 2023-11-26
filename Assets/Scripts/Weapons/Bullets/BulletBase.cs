using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BulletBase : MonoBehaviour
{
    [SerializeField]private Rigidbody2D _rigidbody;
    
    private int _damage;
    private LayerMask _layers;
    private float _shootForce;
    private float _lifetime;
    private Vector2 _moveDirection;

    private bool _impacted;
    
    public UnityEvent OnCollision;
    public UnityEvent OnReachedLimit;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_impacted) return;
        
        if (_layers == (_layers | (1 << other.gameObject.layer)))
        {
            Impact(other);
        }
    }

    public void InitBullet(float shootForce, float lifetime, int damage, Vector2 direction, LayerMask layers)
    {
        _impacted = false;
        _shootForce = shootForce;
        _lifetime = lifetime;
        _damage = damage;
        _moveDirection = direction;
        _layers = layers;
        ShootBullet();
    }

    private void ShootBullet()
    {
        _rigidbody.AddForce(_moveDirection * _shootForce, ForceMode2D.Impulse);
        StartCoroutine(LifetimeCountdown());
    }

    private IEnumerator LifetimeCountdown()
    {
        yield return new WaitForSeconds(_lifetime);
        OnReachedLimit?.Invoke();
        StopBullet();
    }

    private void Impact(Collider2D collider)
    {
        _impacted = true;
        OnCollision?.Invoke();
        StopBullet();
        
        if (collider.TryGetComponent<HealthBase>(out HealthBase health))
        {
            health.TakeDamage(_damage);
        }
    }
    
    private void StopBullet()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
