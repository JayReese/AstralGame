using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScenario : MonoBehaviour
{
    [SerializeField] public float BaseSuccessRate { get; private set; }

    #region Testing.
    float teamAbility, enemyAbility;
    #endregion

    // Use this for initialization
    void Start ()
    {
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

        int allyPoints = 0;
        int pointsNeeded = 1500;

        int allyWins = 0;

        for(int i=0;i<20;i++)
        {
            int res = UnityEngine.Random.Range(50, 100);

            allyPoints += res;
            Debug.Log("Allies got " + res + " points.\nNow have : " + allyPoints);
        }

        if (allyPoints >= pointsNeeded)
            Debug.Log("You win with " + allyPoints);
        else
            Debug.Log("You lose.");

        //if (allyWins >= 10 / 2)
        //    Debug.Log("You win. " + allyWins);
        //else
        //    Debug.Log("You suck.");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}