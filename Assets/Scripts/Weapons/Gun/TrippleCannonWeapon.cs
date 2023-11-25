using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleCannonWeapon : WeaponBase
{
    [SerializeField] private List<CannonWeapon> _cannons;

    private void Awake()
    {
        foreach (CannonWeapon cw in _cannons)
        {
            cw.SetCannonValues(_bulletPrefab, _bulletsAmount, _reloadTime, _fireRate, _damage, _bulletShootForce, _bulletLifespan, _hittableLayers);
        }
    }

    public override void Shoot()
    {
        foreach (CannonWeapon cw in _cannons)
        {
            cw.Shoot();
        }
    }
}
