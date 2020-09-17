using UnityEngine;
using UnityEngine.UI;

namespace SpaceWar
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;

        private Player _player;

        private void Awake()
        {
            _player = FindObjectOfType<Player>();
        }

        private void OnEnable()
        {
            _player.Health.OnHealthChanged += HealthChangedHandler;
        }

        private void HealthChangedHandler(int current, int max)
        {
            healthBar.fillAmount = current / (float)max;
        }

        private void OnDisable()
        {
            _player.Health.OnHealthChanged -= HealthChangedHandler;
        }
    }
}