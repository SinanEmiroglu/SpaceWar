using UnityEngine;
using UnityEngine.UI;

namespace SpaceWar
{
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject levelSelectionPanel;
        [SerializeField] private GameObject levelLoadingPanel;
        [SerializeField] private Slider loadProgressionSlider;

        private void OnEnable()
        {
            GameManager.OnLevelLoading += LevelLoadingHandler;
            GameManager.OnLevelLoaded += LevelLoadedHandler;
            GameManager.OnLevelUnloaded += LevelUnloadedHandler;
        }

        private void LevelLoadingHandler(float progress)
        {
            menuPanel.SetActive(false);
            levelSelectionPanel.SetActive(false);
            levelLoadingPanel.SetActive(true);
            loadProgressionSlider.value = progress;
        }

        private void LevelLoadedHandler(LevelData data)
        {
            gameObject.SetActive(false);
        }

        private void LevelUnloadedHandler()
        {
            levelSelectionPanel.SetActive(true);
            levelLoadingPanel.SetActive(false);
        }

        private void OnDisable()
        {
            GameManager.OnLevelLoading -= LevelLoadingHandler;
            GameManager.OnLevelLoaded -= LevelLoadedHandler;
        }
    }
}