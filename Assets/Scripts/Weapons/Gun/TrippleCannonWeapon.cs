using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippleCannonWeapon : WeaponBase
{
    [SerializeField] private List<CannonWeapon> _cannons;
    
    public override void Shoot()
    {
        foreach (CannonWeapon cw in _cannons)
        {
            cw.Shoot();
        }
    }
}
