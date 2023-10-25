using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public interface ICharacter<T>
{
    public void Live(T obj);
    public abstract void Moved(T obj);
    public void Attacked(T obj);
    public void Upgrade(T obj);  
    public void Died(T obj);
}
