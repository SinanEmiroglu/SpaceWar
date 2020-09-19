using UnityEngine;

namespace SpaceWar
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/LevelData", order = 1)]
    public class LevelData : ScriptableObject
    {
        public int Id;
        public bool IsUnlocked;
        public int ScoreToWin;
        public LevelData NextLevel;
        public Spawnable[] SpawnablePrefabs;
    }
}