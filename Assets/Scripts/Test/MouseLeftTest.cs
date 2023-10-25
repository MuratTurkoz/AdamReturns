using System.Collections;
using System.Collections.Generic;
using Test;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MouseLeftTest : MonoBehaviour
{
    private CharacterController _characterController;
    //[SerializeField] Animator _animator;
    [SerializeField] private PlayerInputTest _playerInputTest;
    private Camera mainCamera;
    private bool isMoving = false;
    [SerializeField] private Vector3 targetPosition;
    public float movementSpeed = 6.0f;
    [SerializeField] private Vector3 moveDirection;
    private bool IsObject = false;
    private float gravityValue = -9.81f;
    private Collider[] _collider = new Collider[3];
    private void Awake()
    {
        transform.position = Vector3.zero;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_playerInputTest.GetMouseLeftClickValue())
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(_playerInputTest.GetPointerPosition());

            if (Physics.Raycast(ray, out hit))
            {
                isMoving = true;
                //_animator.SetFloat("MoveVelocity", 1);
                targetPosition = new Vector3(hit.point.x, 0, hit.point.z);
                //Debug.Log(hit.point);

                //if (hit.transform.CompareTag("Enemy"))
                //{
                //    //IsObject = true;
                //    //TODO:Oyuncu Düþmana göre dönecek
                //    //TODO:Oyuncu Elindeki Silaha Göre Saldýrýr.(Eðer elinde kýlýç varsa yanýnda gidecek silah ya da ok varsa uzaktan olmalý)
                //    //isMoving = false;
                //    //moveDirection = targetPosition - transform.position;
                //    //var angle = -Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg + 90;
                //    ////var angle = -Mathf.Atan2(hit.transform.position.z, hit.transform.position.x) * Mathf.Rad2Deg + 90;
                //    //Vector3 rotDir = new Vector3(0, angle, 0);
                //    //_characterController.transform.rotation = Quaternion.Euler(rotDir);

                //}
                //else
                //{


                //}


                //Debug.Log(hit.transform.name);
            }


            //Physics.OverlapSphere
            //Physics.OverlapSphereNonAlloc(transform.position, 2f, _collider);

            //if (Physics.OverlapSphereNonAlloc(transform.position, 2f, _collider) != 0)
            //{
            //    Debug.Log(_collider[0].name);
            //    //_animator.SetFloat("MoveVelocity", 0);
            //    //isMoving = false;

            //}
        }

        //if (IsObject)
        //{
        //    MoveToTargetRotation();
        //}

        if (isMoving)
        {
            MoveToTargetPosition();
        }
    }

    private void MoveToTargetPosition()
    {

        //Debug.Log("Target Pos: " + targetPosition);
        //Debug.Log("Transform Pos: " + transform.position);
        moveDirection = targetPosition - transform.position;
        //Debug.Log(moveDirection.magnitude);
        var angle = -Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg + 90;
        Vector3 rotDir = new Vector3(0, angle, 0);
        _characterController.transform.rotation = Quaternion.Euler(rotDir);

        Debug.Log(moveDirection.magnitude);
        if (moveDirection.magnitude < 0.2f)
        {
            isMoving = false;
            moveDirection = Vector3.zero;
            //_animator.SetFloat("MoveVelocity", 0);
            rotDir = Vector3.zero;
            return;
        }
        moveDirection = moveDirection.normalized * movementSpeed * Time.deltaTime;
        moveDirection.y += gravityValue * Time.deltaTime;
        _characterController.Move(moveDirection);


    }
    //private void MoveToTargetRotation()
    //{
    //    isMoving = false;

    //    moveDirection = targetPosition - transform.position;
    //    var angle = -Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg + 90;
    //    //var angle = -Mathf.Atan2(hit.transform.position.z, hit.transform.position.x) * Mathf.Rad2Deg + 90;
    //    Vector3 rotDir = new Vector3(0, angle, 0);
    //    _characterController.transform.rotation = Quaternion.Euler(rotDir);
    //}

}
