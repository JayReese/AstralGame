using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class BattleTactics
{
    public CombatStats Stats;
    public CombatStatus Status;

    public BattleTactics(string s)
    {
        SetCombatSpread(s);
    }

    void SetCombatSpread(string s)
    {
        Stats = JsonUtility.FromJson<CombatStats>(File.ReadAllText(Application.streamingAssetsPath + s));
        Status = new CombatStatus(Stats);
    }
}