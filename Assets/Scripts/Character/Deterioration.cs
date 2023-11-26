using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deterioration : MonoBehaviour
{
    private HealthBase _health;

    private void Start()
    {
        _health = GetComponent<HealthBase>();
    }
}
