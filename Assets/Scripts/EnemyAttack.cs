using System;
using UnityEngine;

namespace SpaceWar
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private float delayBetweenAttacks = 1.5f;

        private float _attackTimer = 0;
        private Player _player;

        public int Damage => damage;

        public event Action OnAttack = delegate { };

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        private void Update()
        {
            _attackTimer += Time.deltaTime;

            if (CanAttack())
            {
                Attack();
            }
        }

        private void Attack()
        {
            _attackTimer = 0;
            OnAttack();
        }

        private bool CanAttack()
        {
            return _attackTimer >= delayBetweenAttacks;
        }
    }
}