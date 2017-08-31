using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit
{
    public BattleTactics Tactics;
    

    public enum Allegiances { Ally, Enemy };
    public string type, name;
    public Allegiances Allegiance { get; protected set; }
    
    public Unit target;

    public Unit()
    {
        type = SetUnitType();
    }

    public void ChangeName(int i)
    {
        name = string.Format("{0} {1}", type, i);
    }
    
    protected virtual string SetUnitType()
    {
        return string.Empty;
    }
}
