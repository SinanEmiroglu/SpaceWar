using UnityEngine;

namespace SpaceWar
{
    public class UILevelSelector : MonoBehaviour
    {
        public void OnLevelLoaded(int levelId)
        {
            GameManager.Instance.LoadLevel(levelId);
        }
    }
}