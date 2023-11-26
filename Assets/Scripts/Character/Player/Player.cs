using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerAction _playerAction;
    private MovementBase _playerMovement;
    private HealthBase _playerHealth;

    public PlayerInput Player_Input => _playerInput;
    public PlayerAction Player_Action => _playerAction;
    public MovementBase PlayerMovement => _playerMovement;
    public HealthBase PlayerHealth => _playerHealth;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerAction = GetComponent<PlayerAction>();
        _playerMovement = GetComponent<MovementBase>();
        _playerHealth = GetComponent<HealthBase>();
        
        Init();
    }

    public void Init()
    {
        _playerInput.EnableReceiveInput();
        _playerMovement.EnableMovement();
        _playerHealth.SetMaxHealth();
    }
    
}
