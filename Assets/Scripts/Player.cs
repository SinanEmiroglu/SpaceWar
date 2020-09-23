using UnityEngine;

namespace SpaceWar
{
    public class Player : MonoBehaviour
    {
        public Health Health;

        [SerializeField] private Weapon[] weapons;

        private void Awake()
        {
            GameManager.Instance.Player = this;
        }

        public void WeaponTierUp()
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (!weapons[i].isActiveAndEnabled)
                {
                    weapons[i].gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}