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

        private void Awake()
        {
            _controls = new InputControls();
            _transform = transform;
        }

        private void OnEnable()
        {
            _controls.Enable();
            _controls.Player.Move.performed += MoveHandler;
        }

        private void MoveHandler(InputAction.CallbackContext context)
        {
            _deltaPos = context.ReadValue<Vector2>();
            _deltaPos.Normalize();

            _transform.position += speed * Time.deltaTime * _deltaPos;
        }

        private void OnDisable()
        {
            _controls.Disable();
            _controls.Player.Move.performed -= MoveHandler;
        }
    }
}