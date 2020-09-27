using NUnit.Framework;
using UnityEngine;

namespace SpaceWar.Tests
{
    public class EditModeTests
    {
        private GameObject _player;
        private Health _playerHealth;

        [SetUp]
        public void SetUp()
        {
            _player = new GameObject("Player", typeof(Health));
            _playerHealth = _player.GetComponent<Health>();
        }

        [Test]
        public void _1_Player_Has_Full_Health_When_Game_Started()
        {
            _playerHealth.MaxHealth = 10;
            _playerHealth.OnEnable();

            Assert.AreEqual(_playerHealth.MaxHealth, _playerHealth.CurrentHealth);
        }

        [TestCase(10, 10, 0)]
        [TestCase(10, 11, 0)]
        [TestCase(10, 9, 1)]
        [TestCase(10, 4, 6)]
        [TestCase(10, 0, 10)]
        [TestCase(10, -1, 10)]
        [TestCase(10, -10, 10)]
        public void _2_Player_Take_Hit_By_Amount(int maxHealth, int damage, int expected)
        {
            _playerHealth.MaxHealth = maxHealth;
            _playerHealth.OnEnable();

            _playerHealth.TakeHit(damage);

            Assert.AreEqual(expected, _playerHealth.CurrentHealth);
        }

        [TestCase(20, 10, 10, 20)]
        [TestCase(20, 10, 20, 20)]
        [TestCase(20, 10, -5, 15)]
        [TestCase(20, 10, 0, 10)]
        public void _3_Player_Take_Heal_By_Amount(int maxHealth, int currentHealth, int healAmount, int expected)
        {
            _playerHealth.MaxHealth = maxHealth;
            _playerHealth.CurrentHealth = currentHealth;

            _playerHealth.TakeHeal(healAmount);

            Assert.AreEqual(expected, _playerHealth.CurrentHealth);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_player);
        }
    }
}