namespace SpaceWar
{
    public class LaserEnhancer : Powerup
    {
        protected override void OnUse()
        {
            player.WeaponTierUp();
            ReturnToPool();
        }
    }
}