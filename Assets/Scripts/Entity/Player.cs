using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : CharacterBase
{
    //[SerializeField] string _name;
    //[SerializeField] int _health;
    //[SerializeField] int _power;

    private void Start()
    {
        //CharacterBase _character = new CharacterBase()
        //{
        //    name = _name,
        //    Health = _health,
        //    Power = _power


        //};
    }
    public void PlayerMove()
    {
        Debug.Log("Move");
    }

}
