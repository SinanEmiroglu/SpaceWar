using UnityEngine;

namespace SpaceWar
{
    public class PlayerHealer : Powerup
    {
        [SerializeField] private int healAmount = 3;

        protected override void OnUse()
        {
            player.Health.TakeHeal(healAmount);
            ReturnToPool();
        }
    }
}