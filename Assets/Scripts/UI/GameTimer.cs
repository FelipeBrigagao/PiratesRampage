using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [Header("Text reference")]
    [SerializeField] private TextMeshProUGUI _text;
    private float _maxTime;
    private float _currentGameTime;

    private bool _timeRunning;
    
    private void OnEnable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnStartGameplay.AddListener(StartTimer);
            GameManager.Instance.OnGameEnded.AddListener(StopTimer);
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnStartGameplay.RemoveListener(StartTimer);
            GameManager.Instance.OnGameEnded.RemoveListener(StopTimer);
        }
    }

    private void Awake()
    {
        _maxTime = DataManager.Instance.GameTime;
        _currentGameTime = _maxTime * 60;
    }

    private void Update()
    {
        if (_timeRunning)
        {
            UpdateTimer();
            UpdateTimerUI();
        }
    }

    private void StartTimer()
    {
        _timeRunning = true;
    }
    
    private void StopTimer()
    {
        _timeRunning = false;
    }
    
    private void UpdateTimer()
    {
        _currentGameTime -= Time.deltaTime;

        if (_currentGameTime <= 0)
        {
            StopTimer();
            _currentGameTime = 0;
            UpdateTimerUI();
            GameManager.Instance.OnGameEnded?.Invoke();
        }
    }
    
    private void UpdateTimerUI()
    {
        if((int)(_currentGameTime/60) > 0)
            _text.text = $"{(int)(_currentGameTime / 60)}:{(int)(_currentGameTime % 60)}";
        else
            _text.text = $"{(int)(_currentGameTime % 60)}";
    }
    
}
