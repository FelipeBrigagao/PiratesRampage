using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deterioration Info", menuName = "Health/Deterioration")]
public class DeteriorationInfoSO : ScriptableObject
{
    [Range(0,1)] public float HealthPercentage;
    public List<Parts> DeterioratedParts;
    public int Level;
}
