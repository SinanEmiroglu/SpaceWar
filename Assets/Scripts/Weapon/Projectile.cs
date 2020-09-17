using UnityEngine;

namespace SpaceWar
{
    public class Projectile : PooledMonoBehaviour
    {
        [SerializeField] private int damage = 1;

        [HideInInspector] public Rigidbody2D Rigidbody2D;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

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