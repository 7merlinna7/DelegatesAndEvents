using UnityEngine;

namespace RPGEnemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _damage;
        [SerializeField] protected int _health;
        [SerializeField] protected float _mana;
        public float Damage { get => _damage;}
        public int Health { get => _health;}
        public float Mana { get => _mana;}

    }
}
