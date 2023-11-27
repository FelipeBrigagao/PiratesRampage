using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _timeToSelfDestruct;

    public void ActivateSelfDestruct()
    {
        Destroy(this.gameObject, _timeToSelfDestruct);
    }
}
