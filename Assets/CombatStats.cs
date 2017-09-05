using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatStats
{
    public int HP { get; private set; }
    public int Speed { get; private set; }
    public int Strength { get; private set; }
    public int Range { get; private set; }
    public int Accuracy { get; private set; }

    public CombatStats(UnitStatConfig config)
    {
        Speed = config.Speed;
        HP = config.HP;
        Strength = config.Strength;
        Range = config.Range;
        Accuracy = config.Accuracy;
    }
}