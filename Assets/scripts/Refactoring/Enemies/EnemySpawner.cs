using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private ObjectPooling enemyPool;

    private float _currentTime = 0;

    private void Start()
    {
        enemyPool.SetUp(spawnPosition);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime >= timeToSpawn)
        {
            SpawnEnemy();
            _currentTime = 0;
        }
    }

    public void UpdateSpawningTime(float newTime)
    {
        timeToSpawn = newTime;
    }

    public void SpawnEnemy()
    {
        enemyPool.GetObject();
    }
}
