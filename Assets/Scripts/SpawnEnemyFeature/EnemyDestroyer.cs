using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour 
{
    public event Action<int> EnemiesUpdated;

    [SerializeField] private float _timeToDestroy;
    [SerializeField] private int _enemiesToDestroy;

    private List<Enemy> _enemies;
    private EnemySpawner _enemySpawner;

    public void Awake()
    {
        _enemySpawner = GetComponentInParent<EnemySpawner>();
        _enemySpawner.EnemySpawned += ChooseEnemyDestroyer;

        _enemies = new List<Enemy>();
    }
    private void OnDestroy() => _enemySpawner.EnemySpawned -= ChooseEnemyDestroyer;
     
    private void Update() => Debug.Log(_enemies.Count);

    private void ChooseEnemyDestroyer(DeathType deathType,Enemy enemy)
    {
        _enemies.Add(enemy);
        EnemiesUpdated?.Invoke(_enemies.Count);

        if (deathType == DeathType.Boolean)
        StartCoroutine(DestroyBoolean(enemy));
        else if (deathType ==DeathType.OutOfTime)
            StartCoroutine(DestroyOutOfTime(enemy));
        else if (deathType == DeathType.OutOfEnemies)
            StartCoroutine(DestroyOutOfEnemies(enemy));
    }

    private IEnumerator DestroyBoolean(Enemy enemy)
    {
        yield return new WaitUntil(() => enemy.IsDead == true);
        Destroy(enemy);
    }

    private IEnumerator DestroyOutOfTime(Enemy enemy)
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(enemy);
    }

    private IEnumerator DestroyOutOfEnemies(Enemy enemy)
    {
        yield return new WaitUntil(() => _enemies.Count > _enemiesToDestroy);
        Destroy(enemy);
    }

    private void Destroy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);
        EnemiesUpdated?.Invoke(_enemies.Count);
    }
}