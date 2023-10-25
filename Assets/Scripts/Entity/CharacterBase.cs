using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class CharacterBase : MonoBehaviour
{
    [SerializeField]
    private string Name;
    [SerializeField]
    public int Health;
    [SerializeField]
    public int Power;
    [SerializeField]
    public int AttackPower;
    [SerializeField]
    public bool IsDead;
    [SerializeField]
    public bool IsAttacker;
}

