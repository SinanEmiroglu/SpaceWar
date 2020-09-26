using System;
using UnityEngine;

namespace SpaceWar
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 5;

        public event Action OnTookHit = delegate { };
        public event Action OnDie = delegate { };
        public event Action<int, int> OnHealthChanged = delegate { };

        private int _currentHealth;

        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int CurrentHealth { get => _currentHealth; set => _currentHealth = value; }


        //Visible because of testing purpose.
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
                OnTookHit?.Invoke();
            }
            else
            {
                _currentHealth = 0;
                OnDie?.Invoke();
            }
        }

        public void TakeHeal(int amount)
        {
            int positiveAmount = Mathf.Abs(amount);

            if (_currentHealth >= maxHealth)
            {
                return;
            }

            ModifyHealth(positiveAmount);
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