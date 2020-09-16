using UnityEngine;

namespace SpaceWar
{
    public class WeaponProjectileLauncher : WeaponComponent
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float moveSpeed = 20f;

        protected override void WeaponFired()
        {
            Vector3 direction = firePoint.up;
            Projectile projectile = projectilePrefab.Get<Projectile>(firePoint.position, Quaternion.Euler(direction));

            projectile.Rigidbody2D.velocity = direction * moveSpeed;
        }
    }
}