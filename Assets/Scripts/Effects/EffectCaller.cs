using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCaller : MonoBehaviour
{
    [SerializeField] private List<EffectInfo> _effects;


    public void CallEffect(string effectId)
    {
        foreach (EffectInfo ei in _effects)
        {
            if (ei.Id.Equals(effectId))
            {
                Effect effect = PoolManager.Instance.GetAEffectPool(effectId).TryGetObject();

                if (effect == null)
                {
                    effect = Instantiate(ei.Effect, transform.position, transform.rotation);
                    effect.PlayEffect();
                    PoolManager.Instance.GetAEffectPool(effectId).AddObjectInPool(effect);
                }
                else
                {
                    effect.transform.SetPositionAndRotation(transform.position, transform.rotation);
                    effect.gameObject.SetActive(true);
                    effect.PlayEffect();
                }    
                

            }
        }
    }
    
}
