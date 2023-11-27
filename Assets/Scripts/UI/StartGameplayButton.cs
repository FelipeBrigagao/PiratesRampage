using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameplayButton : MonoBehaviour
{
    public void StartGameplay()
    {
        GameManager.Instance.LoadGameplay();
    }
}
