using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayPanel : MonoBehaviour
{
    [SerializeField] private float _secondsOnScren;

    private void OnEnable()
    {
        StartCoroutine(GoToGameplay());
    }

    private IEnumerator GoToGameplay()
    {
        yield return new WaitForSeconds(_secondsOnScren);
        GameManager.Instance.LoadGameplay();
    }
}
