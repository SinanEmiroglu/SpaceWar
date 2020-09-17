using UnityEngine;

namespace SpaceWar
{
    [RequireComponent(typeof(Weapon))]
    public class WeaponProjectileLauncher : WeaponComponent
    {
        [SerializeField] private float moveSpeed = 20f;
        [SerializeField] private Transform[] firePoints;

        protected override void WeaponFired()
        {
            for (int i = 0; i < firePoints.Length; i++)
            {
                Vector3 direction = firePoints[i].up;
                Projectile prefab = _weapon.ProjectilePrefab;
                Projectile projectile = prefab.Get<Projectile>(firePoints[i].position, Quaternion.Euler(direction));
                projectile.Rigidbody2D.velocity = direction * moveSpeed;
            }
        }
    }
}