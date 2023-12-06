using Input;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Test;
using UnityEngine;
using static UnityEditor.Progress;

public class InteractorTest : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionRadius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private PlayerCharacterMoveTest _characterMoveTest;
    private Collider[] _colliders = new Collider[3];
    public Collider[] Colliders => _colliders;
    [SerializeField] private int _numFound = 0;
    private PlayerInputTest _playerInputTest;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _playerInputTest = GetComponent<PlayerInputTest>();
    }

    // Update is called once per frame
    void Update()
    {

        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionRadius, _colliders, _layerMask);
        if (_numFound > 0)
        {
            if (_colliders[0].gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hi");
                _colliders[0].GetComponentInParent<AITest>().Position = transform.position;
            }
            else
            {
                animator.SetBool("IsAttack", false);
            }

            Debug.Log(_colliders.Length);

            _characterMoveTest.IsMoving = false;


        }
        else
        {
            animator.SetBool("IsAttack", false);

        }

    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(_interactionPoint.position, _interactionRadius);
    //    Gizmos.DrawCube(Vector3.zero,Vector3.up);
    //}
}
