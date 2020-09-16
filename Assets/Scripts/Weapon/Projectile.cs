using UnityEngine;

namespace SpaceWar
{
    public class Projectile : PooledMonoBehaviour
    {
        [SerializeField] private int damage = 1;

        [HideInInspector] public Rigidbody2D Rigidbody2D;

        public int Damage => damage;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                var hitHealth = collision.gameObject.GetComponent<Health>();
                hitHealth.TakeHit(damage);
            }

            ReturnToPool();
        }
    }
}