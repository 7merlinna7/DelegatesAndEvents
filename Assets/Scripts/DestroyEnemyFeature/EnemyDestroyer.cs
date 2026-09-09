using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour 
{
    private Dictionary<Enemy,Func<bool>> _enemiesDeathConditions = new Dictionary<Enemy, Func<bool>>();
    private List<Enemy> _enemiesToRemove = new List<Enemy>();
    public int EnemyCount => _enemiesDeathConditions.Count;

    public void RegisterEnemy(Enemy enemy, Func<bool> condition) => _enemiesDeathConditions[enemy] = condition;

    private void Update()
    {
        if (_enemiesDeathConditions != null)
        {
            foreach (var enemy in _enemiesDeathConditions)
            {
                if (enemy.Value() == true)
                    _enemiesToRemove.Add(enemy.Key);
            }
        }

        foreach (var enemy in _enemiesToRemove)
            Destroy(enemy);
        
        _enemiesToRemove.Clear();

        Debug.Log(_enemiesDeathConditions.Count);
    }

    private void Destroy(Enemy enemy)
    {
        _enemiesDeathConditions.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}