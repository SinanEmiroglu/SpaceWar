using System;
using UnityEngine;

namespace SpaceWar
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 5;

        private int _currentHealth;

        public event Action OnTookHit = delegate { };
        public event Action OnDie = delegate { };
        public event Action<int, int> OnHealthChanged = delegate { };

        private void OnEnable()
        {
            _currentHealth = maxHealth;
            OnHealthChanged?.Invoke(_currentHealth, maxHealth);
        }

        public void TakeHit(int amount)
        {
            if (_currentHealth <= 0)
            {
                return;
            }

            ModifyHealth(-amount);

            if (_currentHealth > 0)
            {
                OnTookHit();
            }
            else
            {
                OnDie();
            }
        }

        public void TakeHeal(int amount)
        {
            if (_currentHealth >= maxHealth)
            {
                return;
            }

            ModifyHealth(amount);
        }

        private void ModifyHealth(int amount)
        {
            _currentHealth += amount;

            if (_currentHealth >= maxHealth)
            {
                _currentHealth = maxHealth;
            }

            OnHealthChanged?.Invoke(_currentHealth, maxHealth);
        }
    }
}