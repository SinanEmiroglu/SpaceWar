using UnityEngine;

namespace SpaceWar
{
    public class ImpactOnDie : MonoBehaviour
    {
        private PooledMonoBehaviour _pooled;

        private void Awake()
        {
            _pooled = GetComponent<PooledMonoBehaviour>();
        }

        private void OnEnable()
        {
            _pooled.OnReturnToPool += (pooled) => Impact();
        }

        protected virtual void Impact() { }

        private void OnDisable()
        {
            _pooled.OnReturnToPool -= (pooled) => Impact();
        }
    }
}