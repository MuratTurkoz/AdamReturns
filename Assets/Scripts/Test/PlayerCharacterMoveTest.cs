using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Test;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacterMoveTest : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] Animator _animator;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    public float PlayerSpeed { get => playerSpeed; set { playerSpeed = value; } }
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    [SerializeField] private PlayerInputTest _playerInputTest;
    private Camera mainCamera;
    private bool isMoving = false;
    public bool IsMoving { get { return isMoving; } set { isMoving = value; } }
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Vector3 moveDirection;

    private void Start()
    {
        mainCamera = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        //Debug.Log(_playerInputTest.GetMouseLeftAttackValue());
        if (_playerInputTest.GetMouseLeftClickValue())
        {
            _animator.SetBool("IsMagic", false);
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(_playerInputTest.GetPointerPosition());

            if (Physics.Raycast(ray, out hit))
            {
                isMoving = true;
                targetPosition = new Vector3(hit.point.x, 0, hit.point.z);
                Debug.Log(hit.collider.name);

            }

        }
        if (_playerInputTest.GetMouseRightClickValue())
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(_playerInputTest.GetPointerPosition());

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Enemy")
                {
                    isMoving = false;
                    targetPosition = new Vector3(hit.point.x, 0, hit.point.z);
                    moveDirection = targetPosition - transform.position;
                    Quaternion.LookRotation(moveDirection.normalized);

                    _animator.SetBool("IsMagic",true);
                }

            }
      


        }
        else
        {
            _animator.SetBool("IsMagic", false);
        }
        //_animator.SetBool("IsMagic", false);


        //Move
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (isMoving)
        {
            
            _animator.SetFloat("MoveVelocity", Convert.ToInt32(isMoving));
            moveDirection = targetPosition - transform.position;
            //Debug.Log(moveDirection.magnitude);
            Quaternion.LookRotation(moveDirection.normalized);
            //var angle = -Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg + 90;
            //Vector3 rotDir = new Vector3(0, angle, 0);
            //controller.transform.rotation = Quaternion.Euler(rotDir);

            if (moveDirection.magnitude < 0.2f)
            {
                isMoving = false;
                moveDirection = Vector3.zero;
                _animator.SetFloat("MoveVelocity", 0);
                //_rotDir = Vector3.zero;
                return;
            }

            moveDirection = moveDirection.normalized * playerSpeed * Time.deltaTime;
            controller.Move(moveDirection);
        }
        else
        {
            _animator.SetFloat("MoveVelocity", Convert.ToInt32(isMoving));
        }


        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
        }

        // Changes the height position of the player..

        if (_playerInputTest.GetJumpValue() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);




    }


}
