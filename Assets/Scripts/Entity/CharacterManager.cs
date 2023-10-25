using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager<T>  where T : class
{
    public void Attacked(T obj)
    {
        throw new System.NotImplementedException();
    }

    public void Died(T obj)
    {
        throw new System.NotImplementedException();
    }

    //public T GetCharacter()
    //{
        
    //    return;
    //}

    public void Live(T obj)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Moved(T obj)
    {
        throw new System.NotImplementedException();
    }

    public void Upgrade(T obj)
    {
        throw new System.NotImplementedException();
    }
    public void Move()
    {

    }


}
