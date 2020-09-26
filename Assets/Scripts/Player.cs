using UnityEngine;

namespace SpaceWar
{
    public class Player : MonoBehaviour
    {
        public static Player Current;

        public Health Health;

        [SerializeField] private Weapon[] weapons;

        private void Awake()
        {
            Current = this;
           // GameManager.Player = this;
        }

        private void OnEnable()
        {
            GameManager.OnGameOver += GameOverHandler;
        }

        private void GameOverHandler(bool obj)
        {
            gameObject.SetActive(false);
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

        private void OnDisable()
        {
            GameManager.OnGameOver -= GameOverHandler;
        }
    }
}