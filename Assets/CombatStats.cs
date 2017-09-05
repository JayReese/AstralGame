using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatStats
{
    public int HP;
    public int Speed;
    public int Strength;
    public int Range;
    public int Accuracy;

    public CombatStats(UnitStatConfig config)
    {

    }

    void SetDefaults(int baseSpd, int hp, int baseStr, int baseRange, int baseAcc)
    {
        Speed = baseSpd;
        HP = hp;
        Strength = baseStr;
        Range = baseRange;
        Accuracy = baseAcc;
    }
}
