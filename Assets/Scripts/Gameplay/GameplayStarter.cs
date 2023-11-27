using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayStarter : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.StartGameplay();
    }
}
