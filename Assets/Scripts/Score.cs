using UnityEngine;

namespace SpaceWar
{
    public class Score : ImpactOnDie
    {
        [SerializeField] private int score;

        protected override void Impact()
        {
            _gameManager.CurrentScore += score;
        }
    }
}