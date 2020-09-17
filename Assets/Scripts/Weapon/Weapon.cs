using System;
using UnityEngine;

namespace SpaceWar
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float fireRateInSecond = 0.25f;

        public Projectile ProjectilePrefab;

        public event Action OnFire = delegate { };

        private float _fireTimer = 0;

        private void Update()
        {
            _fireTimer += Time.deltaTime;

            if (CanFire())
            {
                Fire();
            }
        }

        private bool CanFire()
        {
            return _fireTimer >= fireRateInSecond;
        }

        private void Fire()
        {
            _fireTimer = 0f;
            OnFire();
        }
    }
}