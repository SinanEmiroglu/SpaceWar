using UnityEngine;
using UnityEngine.UI;

namespace SpaceWar
{
    public class UILevelSelector : MonoBehaviour
    {
        [SerializeField] private int levelId;
        [SerializeField] private Button button;

        private void OnEnable()
        {
            button.interactable = GameManager.Instance.IsLevelUnlocked(levelId);
            button.onClick.AddListener(ClickHandler);
        }

        private void ClickHandler()
        {
            GameManager.Instance.LoadLevel(levelId);
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}