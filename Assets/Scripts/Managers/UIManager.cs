using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<UIManager>
{
    [Header("UI references")]
    [SerializeField] private PointsUI _pointsUI;
    [SerializeField] private GameTimer _gameTimer;
    [SerializeField] private GameObject _endGamePanel;

    private void OnEnable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnStartGameplay.AddListener(StartGameplay);
            GameManager.Instance.OnGameEnded.AddListener(EndGame);
        }
    }
    
    private void OnDisable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnStartGameplay.RemoveListener(StartGameplay);
            GameManager.Instance.OnGameEnded.RemoveListener(EndGame);
        }
    }

    public void StartGameplay()
    {
        _pointsUI.gameObject.SetActive(true);
        _gameTimer.gameObject.SetActive(true);
        _endGamePanel.SetActive(false);
    }

    public void EndGame()
    {
        _pointsUI.gameObject.SetActive(false);
        _gameTimer.gameObject.SetActive(false);
        _endGamePanel.SetActive(true);
    }
}
