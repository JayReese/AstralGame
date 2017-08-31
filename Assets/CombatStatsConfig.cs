using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStats
{
    int _baseSpeed, _hp, _baseStr, _baseRange, _baseAcc;

    public CombatStats(int baseSpd, int hp, int baseStr, int baseRange, int baseAcc)
    {
        _baseSpeed = baseSpd;
        _hp = hp;
        _baseStr = baseStr;
        _baseRange = baseRange;
        _baseAcc = baseAcc;
    }
}
