using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGEnemy
{
    public class Elf : Enemy
    {
        public void Initialize(float damage, int health, float mana)
        {
            _damage = damage;
            _health = health;
            _mana = mana;
        }
    }
}
