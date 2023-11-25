using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Actions references")] 
    [SerializeField] private List<ActionCode> _actionCodes;

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
            CheckAction();
        }
    }

    private void ReceiveMovementInput()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
       _player.PlayerMovement.ReceiveInput(_moveInput);
    }

    private void CheckAction()
    {
        foreach(ActionCode ac in _actionCodes)
        {
            if(Input.GetKeyDown(ac.ActionKey))
                CallAction(ac.WeaponId);
        }
    }
    
    private void CallAction(string weaponId)
    {
        _player.Player_Action.CheckWeapon(weaponId);
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
