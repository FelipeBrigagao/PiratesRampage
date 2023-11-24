using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    
    [Header("Movement")]
    [SerializeField] protected float _speed;
    protected Vector2 _input;
    protected bool _canMove;
    
    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public abstract void ReceiveInput(Vector2 input);

    protected abstract void Move();
    protected abstract void Rotate();

    public void StartMovement()
    {
        _canMove = true;
    }
    
    public void StopMovement()
    {
        _canMove = false;
    }
    
}
