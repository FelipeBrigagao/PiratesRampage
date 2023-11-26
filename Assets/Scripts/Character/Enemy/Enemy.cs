using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyAction _enemyAction;
    private EnemyBehaviour _enemyBehaviour;
    private HealthBase _healthBase;
    private MovementBase _movementBase;
    private Deterioration _deterioration;

    public EnemyAction Action => _enemyAction;
    public EnemyBehaviour EnemyBehaviour1 => _enemyBehaviour;
    public HealthBase Health_Base => _healthBase;
    public MovementBase Movement_Base => _movementBase;
    public Deterioration Deterioration => _deterioration;


    private void Start()
    {
        _enemyAction = GetComponent<EnemyAction>();
        _enemyBehaviour = GetComponent<EnemyBehaviour>();
        _healthBase = GetComponent<HealthBase>();
        _movementBase = GetComponent<MovementBase>();
        _deterioration = GetComponent<Deterioration>();
        
        Init();
    }

    public void Init()
    {
        _movementBase.EnableMovement();
    }

    public void StopEnemy()
    {
        
    }
}
