using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon references")]
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected BulletBase _bullet;
    
    [Header("Weapon Values")]
    [SerializeField] protected int _bulletsAmount;
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _bulletSpeed;
    [SerializeField] protected float _bulletLifespan;

    protected ObjectPool<BulletBase> _bulletPool;
    protected bool _canShoot;

    public event Action OnShoot;
    public event Action OnReload;
    
    private void Start()
    {
        _bulletPool = new ObjectPool<BulletBase>();
    }

    protected abstract void Shoot();

    protected IEnumerator Reload()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_reloadTime);
        _canShoot = true;

    }
}
