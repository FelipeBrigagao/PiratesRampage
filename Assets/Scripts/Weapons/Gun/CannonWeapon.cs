using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonWeapon : WeaponBase
{
    private BulletBase _bulletShot;

    public void SetCannonValues(BulletBase bulletPrefab, int bulletsAmount, float reloadTime, float fireRate, int damage, float bulletShootForce, float bulletLifespan, LayerMask hittableLayers)
    {
        _bulletPrefab = bulletPrefab;
        _bulletsAmount = bulletsAmount;
        _reloadTime = reloadTime;
        _fireRate = fireRate;
        _damage = damage;
        _bulletShootForce = bulletShootForce;
        _bulletLifespan = bulletLifespan;
        _hittableLayers = hittableLayers;
    }
    
    public override void Shoot()
    {
        if (_canShoot && Time.time >= _timeToShootNext && _bulletsLeft > 0 )
        {
            _bulletShot = PoolManager.Instance.BulletsPool.TryGetObject();

            if (_bulletShot == null)
            {
                _bulletShot = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
                _bulletShot.InitBullet(_bulletShootForce,_bulletLifespan, _damage, _firePoint.up, _hittableLayers);
                PoolManager.Instance.BulletsPool.AddObjectInPool(_bulletShot);
            }
            else
            {
                _bulletShot.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
                _bulletShot.gameObject.SetActive(true);
                _bulletShot.InitBullet(_bulletShootForce,_bulletLifespan, _damage, _firePoint.up, _hittableLayers);
            }
            
            CallOnShoot();
            _timeToShootNext = Time.time + (1 / _fireRate);
            _bulletsLeft--;
            CheckReload();
        }
    }
}
