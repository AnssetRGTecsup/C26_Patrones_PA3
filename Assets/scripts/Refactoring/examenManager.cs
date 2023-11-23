using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class examenManagerSingleton<T> : MonoBehaviour
    where T : Component
{
    public static T instance { get; private set;}
    public ManagerCoins monedas;
    public virtual void awake()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
