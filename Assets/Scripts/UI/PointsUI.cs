using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [Header("Text reference")]
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        if(DataManager.Instance)
            DataManager.Instance.OnPointsChange.AddListener(UpdateText);
    }
    
    private void OnDisable()
    {
        if(DataManager.Instance)
            DataManager.Instance.OnPointsChange.RemoveListener(UpdateText);
    }

    private void Awake()
    {
        UpdateText(DataManager.Instance.Points);
    }

    public void UpdateText(int points)
    {
        _text.text = points.ToString();
    }
    
    public void UpdateText(string text)
    {
        _text.text = text;
    }
}
