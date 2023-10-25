using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character:CharacterBase
{
    [SerializeField]
    private string Name;
    [SerializeField]
    public int Health;
    [SerializeField]
    public bool IsDead;
    [SerializeField]
    public bool IsAttacker;


}

