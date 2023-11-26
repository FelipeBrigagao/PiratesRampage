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

    public EnemyAction Action => _enemyAction;
    public EnemyBehaviour EnemyBehaviour1 => _enemyBehaviour;
    public HealthBase Health_Base => _healthBase;
    public MovementBase Movement_Base => _movementBase;


    private void Start()
    {
        _enemyAction = GetComponent<EnemyAction>();
        _enemyBehaviour = GetComponent<EnemyBehaviour>();
        _healthBase = GetComponent<HealthBase>();
        _movementBase = GetComponent<MovementBase>();
    }

    public void Init()
    {
        
    }
}
