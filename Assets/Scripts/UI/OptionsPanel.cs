using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    [Header("References game session time")]
    [SerializeField] private Slider _gameSessionTimeSlider;
    [SerializeField] private TextMeshProUGUI _text;

    [Header("References enemies spawn rate time")] 
    [SerializeField] private TMP_InputField _inputField;

    private void OnEnable()
    {
        InitValues();
        _gameSessionTimeSlider.onValueChanged.AddListener(UpdateGameSessionTXT);
    }
    
    private void OnDisable()
    {
        _gameSessionTimeSlider.onValueChanged.AddListener(UpdateGameSessionTXT);
    }

    private void InitValues()
    {
        _gameSessionTimeSlider.value = DataManager.Instance.GameTime;
        _text.text = $"{DataManager.Instance.GameTime.ToString()}min";
        _inputField.text = DataManager.Instance.SpawnRate.ToString();
    }

    private void UpdateGameSessionTXT(float time)
    {
        _text.text = $"{time.ToString()}min";
    }
    
    public void SetValues()
    {
        string valorSpawnRate = _inputField.text;
    
        if(float.TryParse(valorSpawnRate, out float valor))
            DataManager.Instance.SetSpawnRate(valor);
        
        DataManager.Instance.SetGameTime((int)_gameSessionTimeSlider.value);
    }
}
