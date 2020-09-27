using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceWar
{
    public class Asteroid : Spawnable
    {
        [SerializeField] int damage = 5;
        [SerializeField] private int crumbleCount = 2;
        [SerializeField] private Asteroid[] crumblePrefabs;

        public Health Health { get; private set; }
        public NonPlayerMover Mover { get; private set; }

        private Player _player;

        private void Awake()
        {
            Health = GetComponent<Health>();
            Mover = GetComponent<NonPlayerMover>();
        }

        private void OnEnable()
        {
            Health.OnDie += DieHandler;
        }

        private void Start()
        {
            _player = Player.Current;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                _player.Health.TakeHit(damage);
                ReturnToPool();
            }
            else if (collision.gameObject.GetComponent<Shield>() != null)
            {
                Health.Kill();
                ReturnToPool();
            }
        }

        private void DieHandler()
        {
            CrumbleAsteroid();
        }

        private void CrumbleAsteroid()
        {
            for (int i = 0; crumbleCount > 0 && i < crumbleCount; i++)
            {
                Asteroid piece = GetRandomPrefab().Get<Asteroid>(transform.position, Quaternion.identity);

                piece.Mover.Speed = Random.Range(5, 10);
                piece.Mover.Direction = Random.insideUnitCircle.normalized;
            }

            Health.OnDie -= DieHandler;
            ReturnToPool();
        }

        private Asteroid GetRandomPrefab()
        {
            return crumblePrefabs[Random.Range(0, crumblePrefabs.Length)];
        }
    }
}