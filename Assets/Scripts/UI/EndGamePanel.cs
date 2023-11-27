using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePanel : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private TextMeshProUGUI _text;
    
    [Header("Phrases")]
    [SerializeField] private string _timeEndedPhrase;
    [SerializeField] private string _playerDiedPhrase;
    [SerializeField] private Color _timeEndedColor;
    [SerializeField] private Color _playerDiedColor;

    private bool _playerDied = false;
    
    private void OnEnable()
    {
        if(GameManager.Instance)
            GameManager.Instance.OnGameEnded.AddListener(GameEndedByTimer);
        if(PlayerManager.Instance)
            PlayerManager.Instance.OnPlayerDeath.AddListener(GameEndedPlayerDied);
    }

    private void OnDisable()
    {
        if(GameManager.Instance)
            GameManager.Instance.OnGameEnded.RemoveListener(GameEndedByTimer);
        if(PlayerManager.Instance)
            PlayerManager.Instance.OnPlayerDeath.RemoveListener(GameEndedPlayerDied);
    }

    private void GameEndedByTimer()
    {
        if (_playerDied) return;
        _text.color = _timeEndedColor;
        _text.text = _timeEndedPhrase;
    }
    
    private void GameEndedPlayerDied()
    {
        _playerDied = true;
        _text.color = _playerDiedColor;
        _text.text = _playerDiedPhrase;
    }
}
