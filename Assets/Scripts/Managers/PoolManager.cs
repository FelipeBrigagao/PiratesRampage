using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBase<PoolManager>
{
    private ObjectPool<BulletBase> _bulletsPool;

    public ObjectPool<BulletBase> BulletsPool => _bulletsPool;


    private void Start()
    {
        _bulletsPool = new ObjectPool<BulletBase>();
    }
}
