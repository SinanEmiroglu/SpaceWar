using System;
using System.Collections;
using System.Linq;
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

        [SerializeField] private LevelData[] allLevelData;

        public int CurrentScore { get; set; }
        public LevelData CurrentLevelData { get; private set; }

        public void LoadLevel(int levelId)
        {
            StartCoroutine(BeginGameCor(levelId));
        }

        private IEnumerator BeginGameCor(int levelId)
        {
            AsyncOperation opr = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            float progress = Mathf.Clamp01(opr.progress / .9f);
            OnLevelLoading?.Invoke(progress);

            yield return new WaitUntil(() => opr.isDone);

            for (int i = 0; i < allLevelData.Length; i++)
            {
                if (allLevelData[i].Id == levelId)
                {
                    OnLevelLoaded?.Invoke(allLevelData[i]);
                }
            }
        }
    }
}