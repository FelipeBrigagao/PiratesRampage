using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private string _effectNameAnim;
    [SerializeField] private Animator _anim;

    public void PlayEffect()
    {
        _anim.Play(_effectNameAnim);
    }

    public void StopEffect()
    {
        gameObject.SetActive(false);
    }
}
