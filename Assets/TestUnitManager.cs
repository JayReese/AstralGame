﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestUnitManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public UnitStatConfig CreateTestUnits(string s)
    {
        return JsonUtility.FromJson<UnitStatConfig>(File.ReadAllText(Application.streamingAssetsPath + "/JSON/" + s));
    }

    public UnitStatConfig TestCreateStatConfigFile(Unit unitToMap)
    {
        UnitStatConfig newConfig = new UnitStatConfig();

        newConfig.AttackRate = unitToMap.Tactics.Stats.AttackRate;
        newConfig.Strength = unitToMap.Tactics.Stats.Strength;

        return newConfig;
    }

    public void TestPasstoJSON(UnitStatConfig u)
    {


        string newJson = JsonUtility.ToJson(u);

        Debug.Log(newJson);
    }
}
