﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScenario : MonoBehaviour
{
    [SerializeField] public float BaseSuccessRate { get; private set; }

    #region Testing.
    float teamAbility, enemyAbility;
    TestUnitManager UnitManagement;
    #endregion

    // Use this for initialization
    void Start ()
    {
        UnitManagement = GetComponent<TestUnitManager>();

        Rifleman rif = new Rifleman(UnitManagement.CreateTestUnits("Units/RiflemanUnit.json"));

        UnitManagement.TestPasstoJSON(UnitManagement.TestCreateStatConfigFile(rif));

        //Debug.Log(rif.Tactics.Stats.AttackRate);

        teamAbility = 30;
        enemyAbility = 30;

        Debug.Log(teamAbility / enemyAbility);

        int calc = (int)Mathf.Floor(50 * (teamAbility / enemyAbility));

        if (calc >= 90)
            calc = 90;
        else if (calc <= 5)
            calc = 5;

        BaseSuccessRate = calc;

        Debug.Log(BaseSuccessRate);

        int pointsNeeded = 1500;
        int currentPoints = pointsNeeded;
    

        for(int i=0;i<20;i++)
        {
            int res = UnityEngine.Random.Range(50, 100);

            currentPoints -= res;
            Debug.Log("Allies got " + res + " points.\nNow have: " + currentPoints + ".");
        }

        if (currentPoints <= 0)
            Debug.Log("You win.");
        else
            Debug.Log("You lose. " + currentPoints + " left.");


	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}