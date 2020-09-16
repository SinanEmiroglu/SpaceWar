using UnityEngine;

namespace SpaceWar
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            _transform.position += speed * Time.deltaTime * Vector3.down;
        }
    }
}