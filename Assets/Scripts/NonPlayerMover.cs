using UnityEngine;

namespace SpaceWar
{
    public class NonPlayerMover : MonoBehaviour
    {
        [SerializeField] private float speed = 5;

        public float Speed { get => speed; set => speed = value; }
        public Vector3 Direction { get; set; }

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            Direction = -_transform.up;
        }

        private void Update()
        {
            _transform.position += speed * Time.deltaTime * Direction;
        }
    }
}