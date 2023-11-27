using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : SingletonBase<DataManager>
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private int _gameTime;
    private int _points;
    
    public int GameTime => _gameTime;
    public float SpawnRate => _spawnRate;
    public int Points => _points;

    public UnityEvent<int> OnPointsChange;

    public void AddPoints()
    {
        _points++;
        OnPointsChange?.Invoke(_points);
    }

    public void ResetPoints()
    {
        _points = 0;
        OnPointsChange?.Invoke(_points);
    }
     
    public void SetGameTime(int time)
    {
        _gameTime = time;
    }
    
    public void SetSpawnRate(float spawnRate)
    {
        _spawnRate = spawnRate;
    }
}
