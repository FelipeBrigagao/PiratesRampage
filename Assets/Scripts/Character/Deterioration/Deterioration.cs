using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deterioration : MonoBehaviour
{
    [Header("Parts")] 
    [SerializeField] private List<DeteriorationPart> _deteriorationParts;
    [SerializeField] private List<DeteriorationInfoSO> _deteriorationInfo;

    private Dictionary<string, SpriteRenderer> _deteriorationPartsDict = new Dictionary<string, SpriteRenderer>();

    private int _currentLevel = 0;
    
    private HealthBase _health;

    private void Start()
    {
        _health = GetComponent<HealthBase>();

        foreach (DeteriorationPart dp in _deteriorationParts)
        {
            _deteriorationPartsDict.Add(dp.PartId, dp.Part);
        }
        
    }

    public void CheckForDeterioration()
    {
        foreach (DeteriorationInfoSO di in _deteriorationInfo)
        {
            if (_currentLevel >= di.Level) continue;
            
            if (_health.CurrentHealth <= (int)(_health.MaxHealth * di.HealthPercentage))
            {
                _currentLevel = di.Level;
                ChangeParts(di.DeterioratedParts);
            }
        }
    }

    private void ChangeParts(List<Parts> parts)
    {
        foreach (Parts p in parts)
        {
            if (_deteriorationPartsDict.ContainsKey(p.PartId))
            {
                _deteriorationPartsDict[p.PartId].sprite = p.Part;
            }
        }
    }
}
