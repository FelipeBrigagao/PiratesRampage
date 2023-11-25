using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon references")]
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected BulletBase _bulletPrefab;
    
    [Header("Weapon Values")]
    [SerializeField] protected int _bulletsAmount;
    [SerializeField] protected float _reloadTime;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected int _damage;
    [SerializeField] protected float _bulletShootForce;
    [SerializeField] protected float _bulletLifespan;

    protected bool _canShoot;
    protected int _bulletsLeft;
    protected float _timeToShootNext;

    public event Action OnShoot;
    public void CallOnShoot()
    {
        OnShoot?.Invoke();
    }
    
    public event Action OnReload;
    public void CallOnReload()
    {
        OnReload?.Invoke();
    }
    
    
    private void Start()
    {
        _bulletsLeft = _bulletsAmount;
        EnableShooting();
    }

    public abstract void Shoot();

    protected void CheckReload()
    {
        if (_bulletsLeft <= 0)
            StartCoroutine(Reload());
    }
    
    protected IEnumerator Reload()
    {
        _canShoot = false;
        OnReload?.Invoke();
        _bulletsLeft = _bulletsAmount;
        yield return new WaitForSeconds(_reloadTime);
        _canShoot = true;

    }

    public void EnableShooting()
    {
        _canShoot = true;
    }
    
    public void DisableShooting()
    {
        _canShoot = false;
    }
}
