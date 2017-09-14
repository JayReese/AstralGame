using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatus
{
    public int CurrentHP, DistanceFromCenter;
    CombatStats _statsReference;

    public CombatStatus(CombatStats stats)
    {
        _statsReference = stats;
        DistanceFromCenter = Random.Range(2, 15);
    }
}
