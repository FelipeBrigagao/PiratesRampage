using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private float _speed;
    private float _lifetime;
    private int _damage;
    private Vector2 _moveDirection;

    public event Action OnCollision;
    public event Action OnReachedLimit;
    
    public void InitBullet(float speed, float lifetime, int damage, Vector2 direction)
    {
        _speed = speed;
        _lifetime = lifetime;
        _damage = damage;
        _moveDirection = direction;
    }
    
}
