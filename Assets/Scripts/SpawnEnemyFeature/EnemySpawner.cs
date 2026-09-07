using System;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] EnemyDestroyer _enemyDestroyer;
    [SerializeField] float _timeToDestroy;
    [SerializeField] int _maxEnemies;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy enemy = Instantiate(_enemyPrefab, Vector3.up, Quaternion.identity);
            _enemyDestroyer.RegisterEnemy(enemy, () => enemy.IsDead);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            float creationTime = Time.time;
            Enemy enemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
            _enemyDestroyer.RegisterEnemy(enemy, () => Time.time - creationTime >= _timeToDestroy);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Enemy enemy = Instantiate(_enemyPrefab, Vector3.down, Quaternion.identity);
            _enemyDestroyer.RegisterEnemy(enemy, () => _enemyDestroyer.EnemyCount > _maxEnemies);
        }
    }
}
