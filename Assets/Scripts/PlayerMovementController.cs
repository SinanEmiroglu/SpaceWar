using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceWar
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private InputControls _controls;
        private Transform _transform;
        private Vector3 _deltaPos;
        private Camera _mainCamera;

        private float _minX;
        private float _maxX;
        private float _minY;
        private float _maxY;

        private void Awake()
        {
            _controls = new InputControls();
            _transform = transform;
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            _controls.Enable();
            _controls.Player.Move.performed += MoveHandler;
        }

        private void Start()
        {
            _minX = _mainCamera.ViewportToWorldPoint(Vector2.zero).x;
            _maxX = _mainCamera.ViewportToWorldPoint(Vector2.one).x;
            _minY = _mainCamera.ViewportToWorldPoint(Vector2.zero).y;
            _maxY = _mainCamera.ViewportToWorldPoint(Vector2.one).y;
        }

        private void MoveHandler(InputAction.CallbackContext context)
        {
            _deltaPos = context.ReadValue<Vector2>();
            _deltaPos.Normalize();

            _transform.position += speed * Time.deltaTime * _deltaPos;

            float newX = Mathf.Clamp(_transform.position.x, _minX, _maxX);
            float newY = Mathf.Clamp(_transform.position.y, _minY, _maxY);

            _transform.position = new Vector2(newX, newY);
        }

        private void OnDisable()
        {
            _controls.Disable();
            _controls.Player.Move.performed -= MoveHandler;
        }
    }
}