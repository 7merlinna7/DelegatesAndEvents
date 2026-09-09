using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace RPGEnemy
{
    [Serializable]
    public class EnemySettings
    {
        [SerializeField] private List<EnemyConfig> _enemyConfigs;

        private int randomEnemy;
        private EnemyConfig _currentEnemyConfing;

        public int EnemiesConfigCount() => _enemyConfigs.Count;
        public EnemyConfig GetRandomEnemy ()
        {
            if (_enemyConfigs.Count == 0)
                return null;

            randomEnemy = UnityEngine.Random.Range(0, _enemyConfigs.Count);

            _currentEnemyConfing = _enemyConfigs[randomEnemy];
            _enemyConfigs.Remove(_currentEnemyConfing);

            return _currentEnemyConfing;
        }

        [Serializable]
        public class EnemyConfig
        {
            [field: SerializeField] public EnemyType Type { get; private set; }
            [field: SerializeField] public float Damage { get; private set; }
            [field: SerializeField] public int Health { get; private set; }
            [field: SerializeField] public float Mana { get; private set; }
        }
    }
}
