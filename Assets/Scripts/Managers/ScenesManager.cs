using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : SingletonBase<ScenesManager>
{
    [Header("Scenes names")] 
    [SerializeField] private string _mainMenuSceneName;
    [SerializeField] private string _gameplaySceneName;


    public void LoadMainMenu()
    {
        LoadScene(_mainMenuSceneName);
    }
    
    public void LoadGameplay()
    {
        LoadScene(_gameplaySceneName);
    }
    
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    
}
