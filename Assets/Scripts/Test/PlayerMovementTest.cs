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
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float playerSpeed = 2.0f;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;
        [SerializeField] bool isJump;
        [SerializeField] Vector3 move;
        private Plane _plane = new Plane(Vector3.up, Vector3.zero);
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {
            groundedPlayer = _controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            move = _playerInputTest.GetMovedValue();
            isJump = _playerInputTest.GetJumpValue();
            //Debug.Log(move);
            _controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            //Debug.Log(groundedPlayer);
            if (isJump && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
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
                playerVelocity = dir;
                //_characterMovement.Rotation = angle;
            }
            _controller.Move(playerVelocity  * Time.deltaTime);




        }
    }
}

