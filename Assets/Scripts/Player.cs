using UnityEngine;

namespace SpaceWar
{
    public class Player : MonoBehaviour
    {
        public Health Health { get; private set; }

        private void Awake()
        {
            Health = GetComponent<Health>();
        }
    }
}