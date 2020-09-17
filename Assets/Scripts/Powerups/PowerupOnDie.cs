using UnityEngine;

namespace SpaceWar
{
    public class PowerupOnDie : ImpactOnDie
    {
        [Range(0f, 1f)] [SerializeField] private float probability;
        [SerializeField] private Powerup[] powerupPrefabs;

        protected override void Impact()
        {
            if (Random.value < probability)
            {
                OnDieImpact?.Invoke();
                Powerup powerup = GetRandomPowerup().Get<Powerup>();
            }
        }

        private Powerup GetRandomPowerup()
        {
            return powerupPrefabs[Random.Range(0, powerupPrefabs.Length)];
        }
    }
}