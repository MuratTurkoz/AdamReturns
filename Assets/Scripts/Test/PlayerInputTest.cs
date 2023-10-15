using Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Test
{
    public class PlayerInputTest : MonoBehaviour
    {
        private GameInput _gameInput;
        [SerializeField] private Vector2 _moveInput;
        [SerializeField] private bool _jumpedInput;
        [SerializeField] private Vector2 _pointerInput;
        // Start is called before the first frame update
        private void Awake()
        {
            _gameInput = new GameInput();

        }
        private void OnEnable()
        {
            _gameInput.Enable();
            _gameInput.Player.Movement.performed += OnMoved;
            _gameInput.Player.Jump.performed += OnJumped;
            _gameInput.Player.PointerPosition.performed += OnPointerPos;
        }
        private void OnDisable()
        {
            _gameInput.Player.Movement.performed -= OnMoved;
            _gameInput.Player.Jump.performed -= OnJumped;
            _gameInput.Player.PointerPosition.performed -= OnPointerPos;
            _gameInput.Disable();
        }
        private void OnPointerPos(InputAction.CallbackContext context)
        {
            PointerPos();
        }
        private void PointerPos()
        {
            
            _pointerInput = _gameInput.Player.PointerPosition.ReadValue<Vector2>();

        }
        private void OnMoved(InputAction.CallbackContext context)
        {
            Moved();
            //_moveInput = Vector3.zero;
        }
        private void Moved()
        {
            _moveInput = _gameInput.Player.Movement.ReadValue<Vector2>();

        }
        private void OnJumped(InputAction.CallbackContext context)
        {
            Jumped();
        }
        private void Jumped()
        {

            _jumpedInput = _gameInput.Player.Jump.triggered;
        }
        public Vector3 GetMovedValue()
        {
            Vector3 _moveValue = new Vector3(_moveInput.x, 0, _moveInput.y);
            return _moveValue;
        }
        public bool GetJumpValue()
        {
            return _jumpedInput;
        }
        public Vector2 GetPointerPosition()
        {
            return _pointerInput;
        }
        private void Update()
        {
            Moved();
            Jumped();
            PointerPos();
        }

    }

}

