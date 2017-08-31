using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit
{
    public enum Allegiances { Ally, Enemy };
    public string type, name;
    public Allegiances Allegiance;
    public int speed, hp, strength, range, accuracy, cost;
    public Unit target;

    public void ChangeName(int i)
    {
        name = string.Format("{0} {1}", type, i);
    }
}
