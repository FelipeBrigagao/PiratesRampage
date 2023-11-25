using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;


    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                //Debug.Log("Manager not found");

                return FindObjectOfType<T>();
            }

            return _instance;
        }
    }


    protected virtual void Awake()
    {
        if (_instance == null)
        {
            //Debug.Log($"Instantiated Manager:{GetComponent<T>().name}");
            _instance = GetComponent<T>();

        }
        else
        {
            //Debug.LogWarning($"Manager already exist: {GetComponent<T>().name} ");
            Destroy(gameObject);
        }
    }

}
