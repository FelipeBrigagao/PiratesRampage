using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointsManager : SingletonBase<PointsManager>
{
    private int _points;
    public int Points => _points;

    public void AddPoints()
    {
        _points = Points + 1;
    }
}
