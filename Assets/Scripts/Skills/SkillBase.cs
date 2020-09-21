using UnityEngine;

namespace SpaceWar
{
    public abstract class SkillBase : MonoBehaviour
    {
        [SerializeField] private int skillButtonIndex;
        [SerializeField] private float skillRefreshSpeed = 10f;

        public bool CanAttack { get { return skillTimer >= skillRefreshSpeed; } }

        protected float skillTimer;
        protected abstract void OnUse();

        private void OnEnable()
        {
            skillTimer = skillRefreshSpeed;
            SkillInputAction.OnButtonClicked += OnButtonClicked;
        }

        private void OnButtonClicked(int index)
        {
            if (CanAttack && index == skillButtonIndex)
            {
                OnUse();
            }
        }

        private void LateUpdate()
        {
            skillTimer += Time.deltaTime;
        }

        private void OnDisable()
        {
            SkillInputAction.OnButtonClicked -= OnButtonClicked;
        }
    }
}