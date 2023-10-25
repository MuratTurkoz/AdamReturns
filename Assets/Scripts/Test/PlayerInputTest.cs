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
        [SerializeField] private bool _runInput;
        [SerializeField] private bool _mouseLeftInput;
        [SerializeField] private bool _mouseRightInput;
        [SerializeField] private Vector2 _pointerInput;
        [SerializeField] private Vector2 _mouseInput;
        [SerializeField] private bool _mouseLeftAttackInput;
       
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
            _gameInput.Player.Run.performed += OnRun;
            _gameInput.Player.Mouse.performed += OnMousePos;
            _gameInput.Player.MouseLeftClick.performed += OnMouseLeftClick;
            _gameInput.Player.Attack.performed += OnMouseRightAttack;
            _gameInput.Player.MouseRightClick.performed += OnMouseRightClick;
        }
        private void OnDisable()
        {
            _gameInput.Player.Movement.performed -= OnMoved;
            _gameInput.Player.Jump.performed -= OnJumped;
            _gameInput.Player.PointerPosition.performed -= OnPointerPos;
            _gameInput.Player.Run.performed += OnRun;
            _gameInput.Player.Mouse.performed -= OnMousePos;
            _gameInput.Player.Attack.performed -= OnMouseRightAttack;
            _gameInput.Player.MouseLeftClick.performed -= OnMouseLeftClick;
            _gameInput.Player.MouseRightClick.performed -= OnMouseRightClick;
            _gameInput.Disable();
        }
        private void OnMouseRightAttack(InputAction.CallbackContext context)
        {
            //context.action.IsPressed();
            MouseLeftAttack();
        }

        private void OnMouseRightClick(InputAction.CallbackContext context)
        {
            //context.action.IsPressed();
            MouseRightClick();
        }
        private void OnMouseLeftClick(InputAction.CallbackContext context)
        {
            MouseLeftClick();
        }
        private void MouseLeftAttack()
        {
            _mouseLeftAttackInput = _gameInput.Player.Attack.IsPressed();

        }
        private void MouseRightClick()
        {
            _mouseRightInput = _gameInput.Player.MouseRightClick.IsPressed();

        }
        private void MouseLeftClick()
        {
            _mouseLeftInput = _gameInput.Player.MouseLeftClick.IsPressed();

        }

        private void OnMousePos(InputAction.CallbackContext context)
        {
            MousePos();
        }
        private void MousePos()
        {
            _mouseInput = _gameInput.Player.Mouse.ReadValue<Vector2>();

        }
        private void OnRun(InputAction.CallbackContext context)
        {

            Run();
        }
        private void Run()
        {
            _runInput = _gameInput.Player.Run.IsPressed();

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
        public bool GetRunValue()
        {
            return _runInput;
        }
        public bool GetMouseLeftClickValue()
        {
            return _mouseLeftInput;
        }
        public bool GetMouseRightClickValue()
        {
            return _mouseRightInput;
        }
        public Vector2 GetPointerPosition()
        {
            return _pointerInput;
        }
        public Vector2 GetMouseDeltaPosition()
        {
            return _mouseInput;
        }
        public bool GetMouseLeftAttackValue()
        {
            return _mouseLeftAttackInput;
        }
        private void Update()
        {
            //Debug.Log(_runInput);
            Moved();
            Jumped();
            PointerPos();
            Run();
            MousePos();
            MouseLeftAttack();
            //Debug.Log(_mouseInput.sqrMagnitude);
        }
        private void FixedUpdate()
        {
            MouseLeftClick();
            MouseRightClick();
        }

    }

}

