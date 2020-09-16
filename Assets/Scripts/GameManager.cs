using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceWar
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            StartCoroutine(BeginGameCor());
        }

        private IEnumerator BeginGameCor()
        {
            AsyncOperation opr = SceneManager.LoadSceneAsync(1);

            yield return new WaitUntil(() => opr.isDone);

        }
    }
}