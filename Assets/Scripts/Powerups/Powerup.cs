using UnityEngine;

namespace SpaceWar
{
    public class Powerup : PooledMonoBehaviour
    {
        protected Player player;

        private void Awake()
        {
            player = FindObjectOfType<Player>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                OnUse();
            }
        }

        protected virtual void OnUse() { }
    }
}