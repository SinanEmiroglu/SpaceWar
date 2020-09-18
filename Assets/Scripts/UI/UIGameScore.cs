using UnityEngine;

namespace SpaceWar
{
    public class UIGameScore : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI score;

        private void OnEnable()
        {
            GameManager.OnScoreUpdated += ScoreUpdatedHandler;
        }

        private void ScoreUpdatedHandler(int current, int max)
        {
            score.text = $"Score: {current}/{max}";
        }

        private void OnDisable()
        {
            GameManager.OnScoreUpdated -= ScoreUpdatedHandler;
        }
    }
}