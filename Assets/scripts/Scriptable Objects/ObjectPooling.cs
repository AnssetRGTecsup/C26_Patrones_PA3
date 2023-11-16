using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Object Pooling", menuName = "ScriptableObjects/Object Pooling", order = 2)]
public class ObjectPooling : ScriptableObject
{
    [SerializeField] private List<PoolObject> objectPrefabs;

    private Queue<PoolObject> _queueObjects;
    private Transform _parentTransform;

    public event Action OnCreateObject;

    public void SetUp(Transform parent)
    {
        if (_queueObjects == null)
        {
            _queueObjects = new Queue<PoolObject>();
        }

        _queueObjects.Clear();
        _parentTransform = parent;
    }

    public PoolObject GetObject()
    {
        PoolObject prefabOtained;
        if (_queueObjects.TryDequeue(out prefabOtained)){
            prefabOtained.gameObject.SetActive(true);
            prefabOtained.SetUp(this);
        }
        else
        {
            int randomPos = UnityEngine.Random.Range(0, objectPrefabs.Count - 1);
            prefabOtained = Instantiate(objectPrefabs[randomPos], parent: _parentTransform);
        }

        OnCreateObject?.Invoke();

        return prefabOtained;
    }

    public void ReturnObject(PoolObject poolObject)
    {
        _queueObjects.Enqueue(poolObject);
        poolObject.Disable();
    }
}
