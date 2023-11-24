using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private MovementBase _playerMovement;

    public MovementBase PlayerMovement => _playerMovement;
    public PlayerInput Player_Input => _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<MovementBase>();
        
        Init();
    }

    public void Init()
    {
        _playerInput.StartReceiveInput();
        _playerMovement.StartMovement();
    }
    
}
