using UnityEngine;

namespace SpaceWar
{
    public class ImpactOnDie : MonoBehaviour
    {
        protected Health _health;
        protected GameManager _gameManager;

        private void Awake()
        {
            _health = GetComponent<Health>();

            if (GameManager.TryGetInstance(out GameManager manager))
            {
                _gameManager = manager;
            }
        }

        private void OnEnable()
        {
            _health.OnDie += Impact;
        }

        protected virtual void Impact() { }

        private void OnDisable()
        {
            _health.OnDie -= Impact;
        }
    }
}