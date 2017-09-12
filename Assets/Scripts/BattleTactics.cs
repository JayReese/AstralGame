using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class BattleTactics
{
    public CombatStats Stats;
    public CombatStatus Status;

    public BattleTactics(UnitStatConfig newConfig)
    {
        SetCombatSpread(newConfig);
    }

    void SetCombatSpread(UnitStatConfig appliedConfig)
    {
        //Stats = JsonUtility.FromJson<CombatStats>(File.ReadAllText(Application.streamingAssetsPath + s));
        Stats = new CombatStats(appliedConfig);
        Status = new CombatStatus(Stats);
    }
}