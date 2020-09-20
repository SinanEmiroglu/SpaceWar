using UnityEngine;

namespace SpaceWar
{
    public class UIGameplay : MonoBehaviour
    {
        [SerializeField] private GameObject gameplay;
        [SerializeField] private GameObject result;
        [SerializeField] private GameObject resultWin;
        [SerializeField] private GameObject resultLose;

        /// <summary>
        /// Callback in the click event of Return Menu button
        /// </summary>
        public void ReturnMenu()
        {
            GameManager.Instance.HandleReturnMenu();
        }

        /// <summary>
        /// Callback in the click event of Play Next Level button
        /// </summary>
        public void PlayNextLevel()
        {
            GameManager.Instance.HandleNextLevel();
        }

        /// <summary>
        /// Callback in the click event of Replay button
        /// </summary>
        public void Replay()
        {
            GameManager.Instance.Replay();
        }

        private void OnEnable()
        {
            GameManager.OnGameOver += GameOverHander;
        }

        private void GameOverHander(bool isCompleted)
        {
            gameplay.SetActive(false);
            result.SetActive(true);

            if (isCompleted)
            {
                resultWin.SetActive(true);
            }
            else
            {
                resultLose.SetActive(false);
            }
        }

        private void OnDisable()
        {
            resultWin.SetActive(false);
            resultLose.SetActive(false);
            GameManager.OnGameOver -= GameOverHander;
        }
    }
}