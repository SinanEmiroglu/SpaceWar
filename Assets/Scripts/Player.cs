using UnityEngine;

namespace SpaceWar
{
    public class Player : MonoBehaviour
    {
        public Health Health;

        [SerializeField] private Weapon[] weapons;

        private void OnEnable()
        {
            Health.OnDie += DieHander;
        }

        private void DieHander()
        {
            GameManager.Instance.HandleGameOver(false);
        }

        public void WeaponTierUp()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].gameObject.SetActive(true);
            }
        }

        private void OnDisable()
        {
            Health.OnDie -= DieHander;
        }
    }
}