using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] private Vector2 _spawnPositionLimit;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private int _maxEnemiesLimit;

    private EnemyDestroyer _enemyDestroyer;

    private Dictionary<DeathType,Enemy> _enemies;

    private void Awake()
    {
       // _enemyDestroyer
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy _enemy = Instantiate(_enemyPrefab, _spawnPositionLimit, Quaternion.identity);
            
        }
    }

    private void SpawnEnemy()
    {

        Enemy _enemy = Instantiate(_enemyPrefab, _spawnPositionLimit, Quaternion.identity);

    }
}
