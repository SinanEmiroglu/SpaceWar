using UnityEngine;

namespace SpaceWar
{
    public class UIGameScore : MonoBehaviour
    {
        private TMPro.TextMeshProUGUI _score;

        private void Awake()
        {
            _score = GetComponent<TMPro.TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            GameManager.OnScoreUpdated += ScoreUpdatedHandler;
        }

        private void ScoreUpdatedHandler(int current, int max)
        {
            _score.text = $"{current}/{max}";
        }

        private void OnDisable()
        {
            GameManager.OnScoreUpdated -= ScoreUpdatedHandler;
        }
    }
}