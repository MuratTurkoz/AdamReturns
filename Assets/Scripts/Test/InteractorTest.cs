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
                _colliders[0].GetComponentInParent<AITest>().Position = transform.position;

                //animator.SetFloat("MoveVelocity", 0);
                //animator.SetBool("IsAttack", true);
            }
            else
            {
                animator.SetBool("IsAttack", false);
            }
            //RaycastHit hitInfo;
            //bool val = Physics.Raycast(_interactionPoint.position, _colliders[0].transform.position, out hitInfo, 1f);
            //Debug.DrawLine(_interactionPoint.position, _colliders[0].transform.position, Color.red, 1f);
            //Debug.Log(val);
            //if (val)
            //{
            //    if (hitInfo.transform.CompareTag("Enemy"))
            //    {
            //        animator.SetFloat("MoveVelocity", 0);
            //        animator.SetBool("IsAttack",true);
            //    }
            //    else
            //    {
                  

            //    }


            //}
      


            //animator.SetBool("IsAttack", false);
            Debug.Log(_colliders.Length);
            //if (_colliders.Where(z=>z.transform.name=="Enemy").ToList().Count>0)
            //{
            //}
            _characterMoveTest.IsMoving = false;
            //Debug.Log(_colliders);
            //foreach (var item in _colliders)
            //{
            //    //if (item.transform.name == "Cube")
            //    //{
            //    //    Debug.Log("Attack");
            //    //    //return;
            //    //}
            //}

        }
        else
        {
            animator.SetBool("IsAttack", false);

        }


        //Debug.DrawLine(,);
        //bool valueX = Physics.Raycast(transform.position, Vector3.forward, out RaycastHit val, 1f, _layerMask);
        //if (valueX)
        //{
        //    Debug.Log(val.transform.name);
        //}
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(_interactionPoint.position, _interactionRadius);
    //    Gizmos.DrawCube(Vector3.zero,Vector3.up);
    //}
}
