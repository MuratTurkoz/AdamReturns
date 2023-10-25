using Input;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementTest : MonoBehaviour
    {
        private CharacterController _controller;
        [SerializeField] private PlayerInputTest _playerInputTest;
        [SerializeField] private Animator _animator;
        [SerializeField] private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        [SerializeField] private float _playerSpeed = 1f;
        private float _jumpHeight = 1.0f;
        private float _gravityValue = -9.81f;
        private float _runSpeed = 5f;
        private bool _isRun = false;
        [SerializeField] bool _isJump;
        [SerializeField] Vector3 _move;
        private Plane _plane = new Plane(Vector3.up, Vector3.zero);
        private Camera _camera;
        [SerializeField] Vector3 worldPosition;
        [SerializeField] Vector3 dir;


        private bool isMoving = false;
        private Vector3 targetPosition;
        public float movementSpeed = 6.0f;

        private void Start()
        {
            _camera = Camera.main;
            _controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {

            _groundedPlayer = _controller.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }
            _move = _playerInputTest.GetMovedValue();
            _isJump = _playerInputTest.GetJumpValue();
            _isRun = _playerInputTest.GetRunValue();
            if (_isJump && _groundedPlayer)
            {
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            }

            _playerVelocity.y += _gravityValue * Time.deltaTime;

            if (_playerInputTest.GetMouseLeftClickValue())
            {

                var ray = _camera.ScreenPointToRay(_playerInputTest.GetPointerPosition());

                if (_plane.Raycast(ray, out float enter))
                {

                    isMoving = true;
                    worldPosition = ray.GetPoint(enter);
                    //Direction
                    dir = (worldPosition - transform.position).normalized;
                    //Quaternion.LookRotation(dir).eulerAngles.y

                    var angle = -Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg + 90;
                    Vector3 rotDir = new Vector3(0, angle, 0);
                    _controller.transform.rotation = Quaternion.Euler(rotDir);
                    _playerVelocity = new Vector3(dir.x * _playerSpeed, _playerVelocity.y, dir.z * _playerSpeed);


                }

                RaycastHit hit;
                Ray ray1 = _camera.ScreenPointToRay(_playerInputTest.GetPointerPosition());

                if (Physics.Raycast(ray1, out hit))
                {
                    Debug.Log(hit.transform.name);
                }

            }

            if (isMoving)
            {
                MoveToTargetPosition();
            }

        }


        private void MoveToTargetPosition()
        {
            Vector3 moveDirection = targetPosition - transform.position;

            _animator.SetFloat("MoveVelocity", _playerVelocity.magnitude);
            if (moveDirection.magnitude < 1.1f)
            {
                _animator.SetFloat("MoveVelocity", 0);

            }

            moveDirection = moveDirection.normalized * _playerSpeed * Time.deltaTime;

            _playerVelocity = _playerVelocity * _playerSpeed * Time.deltaTime;
            _controller.Move(_playerVelocity);

        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {


        }
    }
}

