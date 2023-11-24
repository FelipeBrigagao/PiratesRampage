using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private bool _canReceiveInput;

    private Vector2 _moveInput;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (_canReceiveInput)
        {
            ReceiveMovementInput();
        }
    }

    private void ReceiveMovementInput()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
       _player.PlayerMovement.ReceiveInput(_moveInput);
    }

    public void EnableReceiveInput()
    {
        _canReceiveInput = true;
    }
    
    public void DisableReceiveInput()
    {
        _canReceiveInput = false;
    }
}
