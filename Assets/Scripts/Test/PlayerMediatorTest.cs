using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PlayerMediatorTest : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private float _health;
    public float Health { get { return _health; } set { _health = value; } }


    private float _attackPower;
    public float AttackPower { get { return _attackPower; } set { _attackPower = value; } }

    [SerializeField] private PlayerCharacterMoveTest _characterMoveTest;
    [SerializeField] private InteractorTest _actorTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (var item in _actorTest.Colliders)
        //{
            
        //}
    }
}
