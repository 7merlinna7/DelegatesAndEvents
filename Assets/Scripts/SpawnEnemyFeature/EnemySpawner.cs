using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy _enemyPrefab;
    private List<Enemy> _enemies;

    private void Awake()
    {
        _enemies = new List<Enemy>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Enemy _enemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
            _enemy.Initialize(DeathType.Boolean);
            _enemies.Add(_enemy);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Enemy _enemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
            _enemy.Initialize(DeathType.OutOfTime);
            _enemies.Add(_enemy);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Enemy _enemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
            _enemy.Initialize(DeathType.OutOfEnemies);
            _enemies.Add(_enemy);
        }
    }
}
