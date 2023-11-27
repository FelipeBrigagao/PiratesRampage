using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : SingletonBase<PlayerManager>
{
    [SerializeField] private Player _playerReference;
    public Player PlayerReference => _playerReference;
    
    public UnityEvent OnPlayerDeath;

    private void OnEnable()
    {
        if(GameManager.Instance)
            OnPlayerDeath.AddListener(GameManager.Instance.OnGameEnded.Invoke);
    }
    
    private void OnDisable()
    {
        if(GameManager.Instance)
            OnPlayerDeath.RemoveListener(GameManager.Instance.OnGameEnded.Invoke);
    }

}
