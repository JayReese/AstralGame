using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScenario : MonoBehaviour
{
    public float BaseSuccessRate { get; private set; }

    #region Testing.
    float teamAbility, enemyAbility;
    #endregion

    // Use this for initialization
    void Start ()
    {
        teamAbility = 19;
        enemyAbility = 30;

        Debug.Log(teamAbility / enemyAbility);

        BaseSuccessRate = (int)Mathf.Floor( 50 * (teamAbility / enemyAbility) );
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}