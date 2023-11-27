using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : SingletonBase<PlayerManager>
{
    [SerializeField] private Player _playerReference;
    public Player PlayerReference => _playerReference;
    
    
    public UnityEvent OnPlayerDeath;
    
}
