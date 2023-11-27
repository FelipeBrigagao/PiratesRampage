using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<Enemy> _enemiesToSpawn;
    [SerializeField] private List<Transform> _spawnPosition;

    private float _spawnRate;
    private Coroutine _spawning;
    private Camera _mainCamera;
    private void OnEnable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnStartGameplay.AddListener(StartSpawning);
            GameManager.Instance.OnGameEnded.AddListener(StopSpawning);
        }    
    }

    private void OnDisable()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.OnStartGameplay.RemoveListener(StartSpawning);
            GameManager.Instance.OnGameEnded.RemoveListener(StopSpawning);
        }    
    }

    private void Awake()
    {
        _spawnRate = DataManager.Instance.SpawnRate;
        _mainCamera = Camera.main;
    }

    private void StartSpawning()
    {
        _spawning = StartCoroutine(Spawn());
    }
    
    private void StopSpawning()
    {
        if (_spawning != null)
        {
            StopCoroutine(_spawning);
            _spawning = null;
        }
    }

    private IEnumerator Spawn()
    {
        Transform position = GetARandomSpawn();
        Enemy enemy = GetARandomEnemy();
        Instantiate(enemy, position.position, position.rotation);
        do
        {
            yield return new WaitForSeconds(_spawnRate);
            position = GetARandomSpawn();
            enemy = GetARandomEnemy();
            Instantiate(enemy, position.position, position.rotation);
        } while (true);
    }
    
    private Transform GetARandomSpawn()
    {
        Transform spawnPos = _spawnPosition[UnityEngine.Random.Range(0, _spawnPosition.Count)];

        while (IsOnScreen(spawnPos))
        {
            spawnPos = _spawnPosition[UnityEngine.Random.Range(0, _spawnPosition.Count)];
        }

        return spawnPos;
    }

    private Enemy GetARandomEnemy()
    {
        return _enemiesToSpawn[UnityEngine.Random.Range(0, _enemiesToSpawn.Count)];
    }

    private bool IsOnScreen(Transform target)
    {
        Vector3 viewportPoint = _mainCamera.WorldToViewportPoint(target.position);

        bool isOnScreen = viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1;

        return isOnScreen;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        foreach (Transform spawn in _spawnPosition)
        {
            Gizmos.DrawSphere(spawn.position, 0.1f);    
        }
    }
}
