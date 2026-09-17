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

                switch (_enemyConfig.Type)
                {
                    case EnemyType.Elf:
                        SpawnElf(_elfPrefab, _enemyConfig, _spawnPointsQueue.Dequeue());
                        break;

                    case EnemyType.Dragon:
                        SpawnDragon(_dragonPrefab, _enemyConfig, _spawnPointsQueue.Dequeue());
                        break;

                    case EnemyType.Ork:
                        SpawnOrk(_orkPrefab, _enemyConfig, _spawnPointsQueue.Dequeue());
                        break;
                }
            }
        }

        private void SpawnElf(Elf elfPrefab, EnemySettings.EnemyConfig enemyConfig,Vector3 spawnPoint)
        {
            Elf elf = Instantiate(elfPrefab, spawnPoint, Quaternion.identity);
            elf.Initialize(enemyConfig.Damage,enemyConfig.Health,enemyConfig.Mana);
        }

        private void SpawnOrk(Ork orkPrefab, EnemySettings.EnemyConfig enemyConfig, Vector3 spawnPoint)
        {
            Ork ork = Instantiate(orkPrefab, spawnPoint, Quaternion.identity);
            ork.Initialize(enemyConfig.Damage, enemyConfig.Health, enemyConfig.Mana);
        }
        private void SpawnDragon(Dragon dragonPrefab, EnemySettings.EnemyConfig enemyConfig, Vector3 spawnPoint)
        {
            Dragon dragon = Instantiate(dragonPrefab, spawnPoint, Quaternion.identity);
            dragon.Initialize(enemyConfig.Damage, enemyConfig.Health, enemyConfig.Mana);
        }
    }
}
