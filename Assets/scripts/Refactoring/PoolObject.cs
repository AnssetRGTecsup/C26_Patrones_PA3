using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
   protected ObjectPooling _currentPool;

   public virtual void SetUp(ObjectPooling currentPool)
   {
        _currentPool = currentPool;
   }

    public virtual void Enable()
    {

    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }
}
