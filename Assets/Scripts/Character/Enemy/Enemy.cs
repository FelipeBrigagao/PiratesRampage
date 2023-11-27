using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAction _enemyAction;
    [SerializeField] private EnemyBehaviour _enemyBehaviour;
    [SerializeField] private HealthBase _healthBase;
    [SerializeField] private MovementBase _movementBase;
    [SerializeField] private Deterioration _deterioration;

    public EnemyAction Action => _enemyAction;
    public EnemyBehaviour Enemy_Behaviour => _enemyBehaviour;
    public HealthBase Health_Base => _healthBase;
    public MovementBase Movement_Base => _movementBase;
    public Deterioration Deterioration => _deterioration;


    private void Awake()
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
        _enemyBehaviour.EnableBehaviours();
        _movementBase.EnableMovement();
        _deterioration.Init();
        _healthBase.Init();
    }

    public void StopEnemy()
    {
        _enemyBehaviour.DisableBehaviours();
        _movementBase.DisableMovement();
        _healthBase.DisableLoseHealth();
    }
}
