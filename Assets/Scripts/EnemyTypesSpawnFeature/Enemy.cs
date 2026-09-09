using UnityEngine;

namespace RPGEnemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private int _health;
        [SerializeField] private float _mana;
        public float Damage { get => _damage;}
        public int Health { get => _health;}
        public float Mana { get => _mana;}

        public void Initialize(float damage, int health,float mana)
        {
            _damage = damage;
            _health = health;
            _mana = mana;
        }
    }
}
