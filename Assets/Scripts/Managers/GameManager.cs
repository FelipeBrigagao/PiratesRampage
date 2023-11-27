using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBase<GameManager>
{
    public UnityEvent OnGameEnded;
    public UnityEvent OnStartGameplay;

    public void LoadMainMenu()
    {
        DataManager.Instance.ResetPoints();
        ScenesManager.Instance.LoadMainMenu();
    }
    
    public void LoadGameplay()
    {
        DataManager.Instance.ResetPoints();
        ScenesManager.Instance.LoadGameplay();
    }

    public void StartGameplay()
    {
        OnStartGameplay?.Invoke();
    }
}
