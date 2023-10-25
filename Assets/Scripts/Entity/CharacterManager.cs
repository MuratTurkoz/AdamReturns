using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Test;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class CharacterManager<T> : MonoBehaviour where T : Character
{
    
    public string GetCharacterName()
    {

        return gameObject.name;
    }
    public void Attacked(T obj)
    {
        throw new System.NotImplementedException();
    }

    public void Died(T obj)
    {
        obj.IsLive = false;
    }

    //public T GetCharacter()
    //{

    //    return;
    //}

    public void Live(T obj)
    {
         
        throw new System.NotImplementedException();
    }

    public virtual void Moved(T obj);


    public void Upgrade(T obj)
    {
        throw new System.NotImplementedException();
    }
    public void Move()
    {

    }


}
