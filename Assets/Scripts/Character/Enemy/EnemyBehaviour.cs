using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy, behaviour geral")]
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _landLayer;
    [SerializeField] private float _checkPlayerRadius;
    [SerializeField] private float _patrolNextPointDistance;
    [SerializeField] private float _distToReachTarget;
    [SerializeField] private float _checkLandRadius;

    [Header("Enemy, behaviour specific")] 
    [SerializeField] private Kamikaze _kamikaze;
    [SerializeField] private List<CannonSides> _cannonSides;
    
    private Enemy _enemy;

    private Collider2D[] _playerCheck;
    private Vector2 _targetPosition;
    private Vector2 _direction;
    private CannonSides _currentSide;
    
    private float _distanceToTarget;
    private bool _goingToPosition;
    private bool _canBehave;
    private float _crossProduct;
    private float _angle;
    private float _angleUp;
    private float _angleRight;
    private float _angleLeft;
    private float _rotation;
    private float _going;

    private Player _player;
    
    private delegate void EnemyBehaviorDelegate();
    private EnemyBehaviorDelegate _currentBehavior;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _currentBehavior = PatrollingBehavior;
        
        switch (_enemyType)
        {
            case EnemyType.CHASER:
                ActivateKamikaze(true);
                break;
            case EnemyType.SHOOTER:
                ActivateKamikaze(false);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (!_canBehave) return;
        
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
        _targetPosition = _player.transform.position;
        _direction = (_targetPosition - (Vector2)transform.position).normalized;

        _angleUp = Vector2.Angle(_direction,transform.up);
        _angleRight = Vector2.Angle(_direction,transform.right);
        _angleLeft = Vector2.Angle(_direction,-transform.right);
        
        if (_angleUp < _angleRight && _angleUp < _angleLeft)
        {
            _angle = _angleUp;
            _crossProduct = _direction.x * transform.up.y - _direction.y * transform.up.x;
            _currentSide = _cannonSides.First(x => x.Side.Equals("Up"));
        }
        else if (_angleRight < _angleUp && _angleRight < _angleLeft)
        {
            _angle = _angleRight;
            _crossProduct = _direction.x * transform.right.y - _direction.y * transform.right.x;
            _currentSide = _cannonSides.First(x => x.Side.Equals("Right"));
        }
        else if (_angleLeft < _angleUp && _angleLeft < _angleRight)
        {
            _angle = _angleLeft;
            _crossProduct = _direction.x * -transform.right.y - _direction.y * -transform.right.x;;
            _currentSide = _cannonSides.First(x => x.Side.Equals("Left"));
        }
        
        _rotation = Mathf.Sign(_crossProduct);
        
        if (Mathf.Abs(_crossProduct) < 0.1f && _angle <= 10f)
        {
            _rotation = 0;
            _enemy.Action.CheckWeapon(_currentSide.CannonId);
        }
        
        _enemy.Movement_Base.ReceiveInput(new Vector2(_rotation, 0f));
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
            _angle = Vector2.Angle(_direction, transform.up);
            _crossProduct = _direction.x * transform.up.y - _direction.y * transform.up.x;
            _rotation = Mathf.Sign(_crossProduct);
            
            if (Mathf.Abs(_crossProduct) < 0.1f && _angle <= 10f)
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
        return centralPoint + (new Vector2(UnityEngine.Random.Range(-_patrolNextPointDistance, _patrolNextPointDistance), UnityEngine.Random.Range(-_patrolNextPointDistance, _patrolNextPointDistance)));
    }

    private void ActivateKamikaze(bool activate)
    {
        if (activate)
        {
            _kamikaze.EnableKamikaze();
            _enemy.Action.DisableWeapons();
        }
        else
        {
            _kamikaze.DisableKamikaze();
            _enemy.Action.EnableWeapons();
        }
    }

    public void EnableBehaviours()
    {
        _canBehave = true;
    }
    
    public void DisableBehaviours()
    {
        _canBehave = false;
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
