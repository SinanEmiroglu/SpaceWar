using UnityEngine;

namespace SpaceWar
{
    public class Strength : Powerup
    {
        protected override void OnUse()
        {
            player.WeaponTierUp();
            ReturnToPool();
        }
    }
}