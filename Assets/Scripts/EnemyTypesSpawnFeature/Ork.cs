using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGEnemy
{
    public class Ork : Enemy
    {
        public void Initialize(float damage, int health, float mana)
        {
            BaseConfig(damage, health, mana);
        }
    }
}
