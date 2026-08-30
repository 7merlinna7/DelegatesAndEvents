using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour 
{
    public event Action<DeathType, Enemy> EnemySpawned;

    private float _timeToDestroy;

    public void Awake()
    {
        EnemySpawned += DestroyEnemy;
    }

    public void Stop()
    {
        EnemySpawned -= DestroyEnemy;
    }

    // корутина вейт антил для условия удаления,  корутинранер - спавнер
    // монобех или нет? DA
    private void DestroyEnemy(DeathType deathType,Enemy enemy)
    {
        if (deathType == DeathType.OutOfTime)
            enemy.Kill(_timeToDestroy);

    }
}
