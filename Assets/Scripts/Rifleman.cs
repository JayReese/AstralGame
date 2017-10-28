using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifleman : Ally
{
    public Rifleman(UnitStatConfig config)
    {
        name = config.Name;
        expertise = config.Expertise;

        Tactics = new BattleTactics(config);
    }

    protected override string SetUnitType()
    {
        return "Rifleman";
    }
}