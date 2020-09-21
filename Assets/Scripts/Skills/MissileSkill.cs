using UnityEngine;

namespace SpaceWar
{
    public class MissileSkill : SkillBase
    {
        [SerializeField] private float missileSpeed = 20f;
        [SerializeField] private Transform launchPoint;
        [SerializeField] private Projectile missilePrefab;

        protected override void OnUse()
        {
            skillTimer = 0;
            var missile = missilePrefab.Get<Projectile>(launchPoint.position, launchPoint.rotation);
            missile.Rigidbody2D.velocity = launchPoint.up * missileSpeed;
        }
    }
}