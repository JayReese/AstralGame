using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifleman : Ally
{
    public Rifleman(UnitStatConfig config)
    {
        name = "Jack R Johnson";
        Tactics = new BattleTactics(config);
    }

    protected override string SetUnitType()
    {
        return "Rifleman";
    }
}