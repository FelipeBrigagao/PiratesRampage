using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBase<PoolManager>
{
    private ObjectPool<BulletBase> _bulletsPool;
    private Dictionary<string, ObjectPool<Effect>> _effectPools;

    public ObjectPool<BulletBase> BulletsPool => _bulletsPool;

    private void Start()
    {
        _bulletsPool = new ObjectPool<BulletBase>();
    }

    public ObjectPool<Effect> GetAEffectPool(string key)
    {
        if (!_effectPools.ContainsKey(key))
        {
            _effectPools.Add(key, new ObjectPool<Effect>());
        }
        return _effectPools[key];
    }

}
