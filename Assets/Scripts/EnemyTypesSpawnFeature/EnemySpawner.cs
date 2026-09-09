using System.Collections.Generic;
using UnityEngine;

namespace RPGEnemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Elf _elfPrefab;
        [SerializeField] private Ork _orkPrefab;
        [SerializeField] private Dragon _dragonPrefab;
        [SerializeField] private List<Transform> _spawnpoints;

        private Queue<Vector3> _spawnPointsQueue;
        private GameObject _currentEnemyGameObject;
        private Enemy _currentEnemy;
        private EnemySettings.EnemyConfig _enemyConfig;

        private void Awake()
        {
            _spawnPointsQueue = new Queue<Vector3>();
            foreach (Transform point in _spawnpoints)
                _spawnPointsQueue.Enqueue(point.position);
        }

        public void SpawnEnemies(EnemySettings enemySettings,EnemyType enemyType) 
        {
            while(enemySettings.EnemiesConfigCount() > 0)
            {
                _enemyConfig = enemySettings.GetRandomEnemy();
                if (_enemyConfig == null)
                    break;

                if (enemyType == EnemyType.Elf)
                    Spawn(_elfPrefab, _enemyConfig,_spawnPointsQueue.Dequeue());
                else if (enemyType == EnemyType.Ork)
                    Spawn(_orkPrefab, _enemyConfig, _spawnPointsQueue.Dequeue());
                else if (enemyType == EnemyType.Dragon)
                    Spawn(_dragonPrefab, _enemyConfig, _spawnPointsQueue.Dequeue());
            }
        }

        private void Spawn(Enemy enemyPrefab,EnemySettings.EnemyConfig enemyConfig,Vector3 spawnPoint)
        {
            _currentEnemyGameObject = Instantiate(enemyPrefab.gameObject, spawnPoint, Quaternion.identity);
            _currentEnemy =_currentEnemyGameObject.GetComponent<Enemy>();
            _currentEnemy.Initialize(enemyConfig.Damage,enemyConfig.Health,enemyConfig.Mana);
        }
    }
}
