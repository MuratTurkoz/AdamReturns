using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject
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

