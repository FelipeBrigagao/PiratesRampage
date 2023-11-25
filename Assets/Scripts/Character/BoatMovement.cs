using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MovementBase
{
    [Header("Movement boat")] [SerializeField]
    private float _maxSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField][Range(0,1)] private float _driftAmount;

    [Header("Drag")] [SerializeField] private float dragAmount;
    
    private Quaternion _rotateAngle;
    private float _angle;
    private float _velocityUpMax;
    private Vector2 _velocityUpDrift;
    private Vector2 _velocityRightDrift;
    
    protected override void Start()
    {
        base.Start();

    }

    private void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
            Rotate();
            
        }
        
        ApplyDrag();
        ApplyDrift();
        
    }


    public override void ReceiveInput(Vector2 input)
    {
        _input = input;
    }

    protected override void Move()
    {
        _velocityUpMax = Vector2.Dot(transform.up, _rigidbody.velocity);
        if (_velocityUpMax > _maxSpeed) return;
        if (_velocityUpMax < (-_maxSpeed * 0.5f)) return;
        
        _rigidbody.AddForce(transform.up * (_speed * _input.y * Time.deltaTime), ForceMode2D.Force);
    }

    protected override void Rotate()
    {
        _angle = _rotateSpeed * _input.x * Time.deltaTime;
        _rotateAngle = Quaternion.Euler(0, 0, -_angle);
        _rigidbody.MoveRotation(transform.rotation * _rotateAngle);
    }

    private void ApplyDrift()
    {
        _velocityUpDrift = transform.up * Vector2.Dot(_rigidbody.velocity, transform.up);
        _velocityRightDrift = transform.right * Vector2.Dot(_rigidbody.velocity, transform.right);
        _rigidbody.velocity = _velocityUpDrift + _velocityRightDrift * _driftAmount;
    }

    private void ApplyDrag()
    {
        if (_input.y == 0)
            _rigidbody.drag = Mathf.Lerp(_rigidbody.drag, dragAmount, Time.fixedDeltaTime);
        else
            _rigidbody.drag = 0;

    }
}
