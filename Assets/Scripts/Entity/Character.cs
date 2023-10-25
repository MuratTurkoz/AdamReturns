using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : ICharacterBase
{
    private string _name;
    public string Name { get => _name; set => _name = value; }
    public bool IsLive { get; set; }
    public float HealthValue { get; set; }
    public float JumpSpeed { get; set; }
    public float Speed { get; set; }
    public float MagicValue { get; set; }
    public bool IsWeapon { get; set; }
    public ICharacterBase.MoveBehaviour GetMoveBehaviour { get; set; }
    public ICharacterBase.AttackBehaviour GetAttack { get; set; }



}

