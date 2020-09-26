using UnityEngine;

namespace SpaceWar
{
    public class Powerup : PooledMonoBehaviour
    {
        protected Player player;

        private void Start()
        {
            player = Player.Current;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject == player.gameObject)
            {
                OnUse();
            }
        }

        protected virtual void OnUse() { }
    }
}