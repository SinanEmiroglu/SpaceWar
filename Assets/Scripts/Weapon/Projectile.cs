using UnityEngine;

namespace SpaceWar
{
    public class Projectile : PooledMonoBehaviour
    {
        [HideInInspector] public Rigidbody2D Rigidbody2D;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ReturnToPool();
        }
    }
}