using Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementTest : MonoBehaviour
    {
        private CharacterController _controller;
        [SerializeField] private PlayerInputTest _playerInputTest;
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        private float _playerSpeed = 1f;
        private float _jumpHeight = 1.0f;
        private float _gravityValue = -9.81f;
        private float _runSpeed = 5f;
        private bool _isRun = false;
        [SerializeField] bool _isJump;
        [SerializeField] Vector3 _move;
        private Plane _plane = new Plane(Vector3.up, Vector3.zero);
        private Camera _camera;

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
            //Debug.Log(_isRun);
            //_isRun == true ? _playerSpeed = _runSpeed : _playerSpeed = 2f;


            if (_isRun)
            {

                _playerSpeed = _runSpeed;
            }
            else
            {
                _playerSpeed = 1f;
            }
            //Debug.Log(move);
            //_controller.Move(_move * Time.deltaTime * _playerSpeed);

            if (_move != Vector3.zero)
            {
                gameObject.transform.forward = _move;
            }

            // Changes the height position of the player..
            //Debug.Log(_groundedPlayer);
            if (_isJump && _groundedPlayer)
            {
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            }
            //playerVelocity.y += gravityValue * Time.deltaTime;

            _playerVelocity.y += _gravityValue * Time.deltaTime;
            //move = Vector3.zero;
            //isJump = false;

            var ray = _camera.ScreenPointToRay(_playerInputTest.GetPointerPosition());

            if (_plane.Raycast(ray, out float enter))
            {
                var worldPosition = ray.GetPoint(enter);
                var dir = (worldPosition - transform.position).normalized;
                //Quaternion.LookRotation(dir).eulerAngles.y

                var angle = -Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg + 90;
                Vector3 rotDir = new Vector3(0, angle, 0);
                _controller.transform.rotation = Quaternion.Euler(rotDir);
                _playerVelocity = new Vector3(dir.x*_playerSpeed, _playerVelocity.y, dir.z*_playerSpeed);
                //_characterMovement.Rotation = angle;
            }
            //if (_isRun == true)
            //{
            //    _controller.Move(_playerVelocity * _runSpeed * Time.deltaTime);

            //    //_playerSpeed = _runSpeed;
            //}
            //else
            //{
            //    _controller.Move(_playerVelocity * _playerSpeed * Time.deltaTime);

            //    //_playerSpeed = 2f;
            //}
            _controller.Move(_playerVelocity  * Time.deltaTime);




        }
    }
}

