using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterBase
{

    public string Name { get; set; }
    public bool IsLive { get; set; }
    public float HealthValue { get; set; }
    public float JumpSpeed { get; set; }
    public float Speed { get; set; }
    public float MagicValue { get; set; }
    public bool IsWeapon { get; set; }
    public MoveBehaviour GetMoveBehaviour { get; set; }
    public AttackBehaviour GetAttack { get; set; }

    public enum MoveBehaviour
    {
        Idle, Walked, Runned, Jumped
    }
    public enum AttackBehaviour
    {
        IsLeftClickAttack, IsRightClickAttack
    }


}

