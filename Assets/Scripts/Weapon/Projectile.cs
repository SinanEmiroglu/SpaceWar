using UnityEngine;

namespace SpaceWar
{
    public class Projectile : PooledMonoBehaviour
    {
        [SerializeField] private int damage = 1;

        public Rigidbody2D Rigidbody2D;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Health>() != null)
            {
                var hitHealth = other.gameObject.GetComponent<Health>();
                hitHealth.TakeHit(damage);
            }

            ReturnToPool();
        }
    }
}