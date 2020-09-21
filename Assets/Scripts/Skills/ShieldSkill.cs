using UnityEngine;

namespace SpaceWar
{
    public class ShieldSkill : SkillBase
    {
        [SerializeField] private float duration;
        [SerializeField] private Shield shieldPrefab;

        private Transform _transform;
        private Shield _currentShield;

        private void Awake()
        {
            _transform = transform;
        }

        protected override void OnUse()
        {
            skillTimer = 0;
            _currentShield = shieldPrefab.Get<Shield>(transform.position, transform.rotation);
            _currentShield.ReturnToPool(duration);
        }

        private void Update()
        {
            if (_currentShield != null && _currentShield.gameObject.activeInHierarchy)
            {
                _currentShield.transform.position = _transform.position;
            }
        }
    }
}