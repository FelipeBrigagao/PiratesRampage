using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T: MonoBehaviour
{
    private List<T> _objectsPool = new List<T>();


    public T TryGetObject()
    {
        foreach (T obj in _objectsPool)
        {
            if (obj.gameObject.activeInHierarchy) continue;
            return obj;
        }

        return null;
    }

    public void AddObjectInPool(T newObj)
    {
        _objectsPool.Add(newObj);
    }
    
}
