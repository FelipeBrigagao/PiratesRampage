using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonBase<PoolManager>
{
    public ObjectPool<BulletBase> BulletsPool;

    private void Start()
    {
        BulletsPool = new ObjectPool<BulletBase>();
    }
}
