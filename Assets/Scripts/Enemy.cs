namespace SpaceWar
{
    public class Enemy : Spawnable
    {
        public Health Health { get; private set; }

        private void Awake()
        {
            Health = GetComponent<Health>();
        }

        private void Start()
        {
            Health.OnDie += () => ReturnToPool();
        }
    }
}