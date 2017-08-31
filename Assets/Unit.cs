using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit
{
    public CombatStatsConfig CombatStats;

    public enum Allegiances { Ally, Enemy };
    public string type, name;
    public Allegiances Allegiance;
    int speed, hp, strength, range, accuracy, cost,
               distanceFromCenter;
    public Unit target;

    public Unit()
    {
        CombatStats = new CombatStatsConfig();
    }

    public void ChangeName(int i)
    {
        name = string.Format("{0} {1}", type, i);
    }
}
