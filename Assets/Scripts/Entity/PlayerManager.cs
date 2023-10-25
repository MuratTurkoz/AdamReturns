using Polyperfect.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager<Player>
{
    [SerializeField] Player _player;
    void Start()
    {
        Moved(_player);
    }

    // Update is called once per frame
    void Update()
    {

    }
    

}
