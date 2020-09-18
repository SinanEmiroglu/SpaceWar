using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceWar
{
    public class GameManager : Singleton<GameManager>
    {
        public static event Action<int, int> OnScoreUpdated = delegate { };
        public static event Action<float> OnLevelLoading = delegate { };
        public static event Action<LevelData> OnLevelLoaded = delegate { };
        public static event Action OnLevelUnloaded = delegate { };
        public static event Action OnGameOver = delegate { };

        [SerializeField] private LevelData[] allLevelData;

        public LevelData CurrentLevelData { get; private set; }
        public int CurrentScore
        {
            get => _currentScore;
            set
            {
                _currentScore = value;
                if (_currentScore >= CurrentLevelData.ScoreToWin)
                {
                    OnGameOver?.Invoke();
                }
                OnScoreUpdated?.Invoke(_currentScore, CurrentLevelData.ScoreToWin);
            }
        }

        private int _currentScore = 0;

        public void LoadLevel(int levelId)
        {
            StartCoroutine(BeginGameCor(levelId));
        }

        private IEnumerator BeginGameCor(int levelId)
        {
            AsyncOperation opr = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            while (!opr.isDone)
            {
                float progress = Mathf.Clamp01(opr.progress / 0.9f);
                OnLevelLoading?.Invoke(progress);
                yield return null;
            }

            for (int i = 0; i < allLevelData.Length; i++)
            {
                if (allLevelData[i].Id == levelId)
                {
                    CurrentLevelData = allLevelData[i];
                    CurrentScore = 0;
                    OnLevelLoaded?.Invoke(allLevelData[i]);
                }
            }
        }
    }
}