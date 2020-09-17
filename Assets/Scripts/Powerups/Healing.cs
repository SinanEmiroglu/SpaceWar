using UnityEngine;

namespace SpaceWar
{
    public class Healing : Powerup
    {
        [SerializeField] private int healAmount = 3;

        protected override void OnUse()
        {
            player.Health.TakeHeal(healAmount);
            ReturnToPool();
        }
    }
}