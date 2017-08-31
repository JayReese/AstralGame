﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifleman : Ally
{
    public Rifleman()
    {
        Tactics = new BattleTactics("/JSON/Units/RiflemanUnit.json");
    }

    protected override string SetUnitType()
    {
        return "Rifleman";
    }
}