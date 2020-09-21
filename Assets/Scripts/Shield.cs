namespace SpaceWar
{
    public class Shield : PooledMonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        private void OnEnable()
        {
            // Heal Player in time
        }
    }
}