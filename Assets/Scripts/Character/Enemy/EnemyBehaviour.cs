using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _landLayer;
    [SerializeField] private float _timeToLostPlayer;
    [SerializeField] private float _checkPlayerRadius;
    [SerializeField] private float _patrolNextPointDistance;
    [SerializeField] private float _distToReachTarget;
    [SerializeField] private float _checkLandRadius;

    private Enemy _enemy;

    private Collider2D[] _playerCheck;
    private Vector2 _targetPosition;
    private Vector2 _direction;
    
    private float _distanceToTarget;
    private bool _goingToPosition;
    private float _crossProduct;
    private float _rotation;
    private float _going;

    private Player _player;
    
    private delegate void EnemyBehaviorDelegate();
    private EnemyBehaviorDelegate _currentBehavior;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _currentBehavior = PatrollingBehavior;
    }

    private void Update()
    {
        CheckForPlayer();
        _currentBehavior?.Invoke();
    }

    private void CheckForPlayer()
    {
        _playerCheck = Physics2D.OverlapCircleAll(this.transform.position, _checkPlayerRadius,_playerLayer);

        if (_playerCheck.Length > 0)
        {
            if (_player != null)
                return;
            else
                _player = _playerCheck[0].GetComponent<Player>();
            
            _goingToPosition = false;
            
            switch (_enemyType)
            {
                case EnemyType.CHASER:
                    _currentBehavior = ChaserBehavior;
                    break;
                case EnemyType.SHOOTER:
                    _currentBehavior = ShooterBehavior;
                    break;
                default:
                    _currentBehavior = PatrollingBehavior;
                    break;
            }
        }
        else
        {
            _currentBehavior = PatrollingBehavior;
            _player = null;
        }
        
    }
    
    private void PatrollingBehavior()
    {
        if (_goingToPosition)
        {
            GoToTargetPosition();
        }
        else
        {
            Collider2D col;
            do
            {
                _targetPosition = GetRandomPosition(transform.position);
                col = Physics2D.OverlapCircle(_targetPosition, _checkLandRadius, _landLayer);
            } while(col != null);
        
            _goingToPosition = true;
        }
    }

    private void ChaserBehavior()
    {
        if (_goingToPosition)
        {
            _targetPosition = _player.transform.position;
            GoToTargetPosition();
        }
        else
        {
            _goingToPosition = true;
            _targetPosition = _player.transform.position;
        }
    }

    private void ShooterBehavior()
    {
        
    }

    private void GoToTargetPosition()
    {
        _distanceToTarget = Vector2.Distance(transform.position, _targetPosition);
        
        if (_distanceToTarget < _distToReachTarget)
        {
            _goingToPosition = false; 
        }
        else
        {
            _direction = (_targetPosition - (Vector2)transform.position).normalized;
            _crossProduct = Vector3.Cross(_direction, transform.up).z;
            _rotation = Mathf.Sign(_crossProduct);
            
            Debug.Log($"Rotation:{_rotation}         Cross:{_crossProduct}");
            if (Mathf.Abs(_crossProduct) < 0.1f)
            {
                _rotation = 0;
                _going = 1;
            }
            else
            {
                _going = 0;
            }
            
            _enemy.Movement_Base.ReceiveInput(new Vector2(_rotation, _going));
        }
    }
    
    private Vector2 GetRandomPosition(Vector2 centralPoint)
    {
        return centralPoint + (new Vector2(Random.Range(-_patrolNextPointDistance, _patrolNextPointDistance), Random.Range(-_patrolNextPointDistance, _patrolNextPointDistance)));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _patrolNextPointDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _checkPlayerRadius);
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(_targetPosition, 0.5f);
    }
}

public enum EnemyType
{
    SHOOTER,
    CHASER
}
