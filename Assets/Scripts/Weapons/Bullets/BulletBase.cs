using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField]private Rigidbody2D _rigidbody;
    
    private float _shootForce;
    private float _lifetime;
    private int _damage;
    private Vector2 _moveDirection;

    public event Action OnCollision;
    public event Action OnReachedLimit;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void InitBullet(float shootForce, float lifetime, int damage, Vector2 direction)
    {
        _shootForce = shootForce;
        _lifetime = lifetime;
        _damage = damage;
        _moveDirection = direction;
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
        StopBullet();
    }

    private void StopBullet()
    {
        _rigidbody.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
