using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [Header("Weapons reference")] 
    [SerializeField] private List<WeaponInfo> _weaponsList;


    public void CheckWeapon(string weaponId)
    {
        foreach (WeaponInfo wi in _weaponsList)
        {
            if (wi.WeaponId.Equals(weaponId))
            {
                MakeAWeaponAction(wi.Weapon);
            }
        }
    }

    private void MakeAWeaponAction(WeaponBase weapon)
    {
        weapon?.Shoot();
    }
    
}
