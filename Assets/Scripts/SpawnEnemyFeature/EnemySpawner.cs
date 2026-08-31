using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action<DeathType, Enemy> EnemySpawned;

    [SerializeField] Enemy _enemyPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnEnemy(DeathType.Boolean, Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnEnemy(DeathType.OutOfTime,Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnEnemy(DeathType.OutOfEnemies, Vector3.down);
        }
    }

    private void SpawnEnemy(DeathType deathType, Vector3 position)
    {
        Enemy _enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        EnemySpawned?.Invoke(deathType, _enemy);
    }
}
