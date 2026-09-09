using UnityEngine;

namespace RPGEnemy
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private EnemySettings _elfsEnemySettings;
        [SerializeField] private EnemySettings _orksEnemySettings;
        [SerializeField] private EnemySettings _dragonsEnemySettings;

        [SerializeField] private EnemySpawner _enemySpawner;

        private void Awake()
        {
            _enemySpawner.SpawnEnemies(_elfsEnemySettings,EnemyType.Elf);
            _enemySpawner.SpawnEnemies(_orksEnemySettings, EnemyType.Ork);
            _enemySpawner.SpawnEnemies(_dragonsEnemySettings, EnemyType.Dragon);
        }
    }
}
