using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatStats
{
    public int Strength { get; private set; }
    public int AttackRate { get; private set; }

    public int Range { get; private set; }
    public int Accuracy { get; private set; }



    public CombatStats(UnitStatConfig config)
    {
        Strength = config.Strength;
        AttackRate = config.AttackRate;
        
    }
}