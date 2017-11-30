using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScenario : MonoBehaviour
{
    public float BaseSuccessRate { get; private set; }

    #region Testing.
    float teamAbility, enemyAbility;
    TestUnitManager UnitManagement;
    List<GameObject> DamageSources;
    int enemyHP, allyHP, numberOfEnemies;
    float timer;
    bool battleHasStarted;
    List<int> disabledNumber;
    #endregion

    // Use this for initialization
    void Start ()
    {
        InitializeTestBattleScenario();
    }

    #region Testing methods.
    void InitializeTestBattleScenario()
    {

        #region The commented out part of the battle scenario test.
        //UnitManagement = GetComponent<TestUnitManager>();

        //Rifleman rif = new Rifleman(UnitManagement.CreateTestUnits("Testing/RiflemanUnit.json"));

        //UnitManagement.TestPasstoJSON(UnitManagement.TestCreateStatConfigFile(rif));

        ////Debug.Log(rif.Tactics.Stats.AttackRate);

        //teamAbility = 30;
        //enemyAbility = 30;

        //Debug.Log(teamAbility / enemyAbility);

        //int calc = (int)Mathf.Floor(50 * (teamAbility / enemyAbility));

        //if (calc >= 90)
        //    calc = 90;
        //else if (calc <= 5)
        //    calc = 5;

        //BaseSuccessRate = calc;

        //Debug.Log(BaseSuccessRate);

        //int pointsNeeded = 1500;
        //int currentPoints = pointsNeeded;


        //for(int i=0;i<20;i++)
        //{
        //    int res = UnityEngine.Random.Range(50, 100);

        //    currentPoints -= res;
        //    Debug.Log("Allies got " + res + " points.\nNow have: " + currentPoints + ".");
        //}

        //if (currentPoints <= 0)
        //    Debug.Log("You win.");
        //else
        //    Debug.Log("You lose. " + currentPoints + " left.");
        #endregion

        battleHasStarted = false;
        GameObject o;
        DamageSources = new List<GameObject>();
        numberOfEnemies = 8;
        enemyHP = 400 * numberOfEnemies;

        disabledNumber = new List<int>();

        timer = 3;

        for (int i = 1; i < 6; i++)
        {
            o = Instantiate(Resources.Load("Test Unit") as GameObject);
            o.GetComponent<TestingDamageSource>().SetName(i);
            DamageSources.Add(o);
        }

        TestStartDisabledNumberAlloc();

        //disabledNumber.ForEach(x => Debug.Log(x));
    }

    void TestStartDisabledNumberAlloc()
    {
        if (disabledNumber.Count == 0) disabledNumber.Add(UnityEngine.Random.Range(0, 6));

        for (int i = 0; i < 1; i++)
        {
            int res = UnityEngine.Random.Range(0, 6);
            bool exists = false;

            foreach (int a in disabledNumber)
                exists = a == res;

            if (!exists) disabledNumber.Add(res);
            else TestStartDisabledNumberAlloc();
        }
    }

    private IEnumerator TestBattleStart()
    {
        foreach (GameObject go in DamageSources)
        {
            allyHP += go.GetComponent<TestingDamageSource>().HP;
        }

        Debug.Log("Ally! " + allyHP + ", Enemy! " + enemyHP);

        Debug.Log("started battle");

        battleHasStarted = true;
        while (enemyHP > 0 && allyHP > 0)
        {
            #region Ally side.
            for (int i = 0; i < DamageSources.Count; i++)
            {
                yield return new WaitForSeconds(0.2f);

                int res;
                res = UnityEngine.Random.Range(0, 100);

                if (res <= DamageSources[i].GetComponent<TestingDamageSource>().SuccessChance)
                {
                    Debug.Log(string.Format("{0} hit, {1} damage done.", DamageSources[i].GetComponent<TestingDamageSource>().Name, DamageSources[i].GetComponent<TestingDamageSource>().DamageToDeal));

                    enemyHP -= DamageSources[i].GetComponent<TestingDamageSource>().DamageToDeal;
                }
                else
                {
                    Debug.Log(string.Format("{0} missed.", DamageSources[i].GetComponent<TestingDamageSource>().Name));
                }

                res = UnityEngine.Random.Range(0, 100);

                DamageSources[i].GetComponent<TestingDamageSource>().AdvanceTime();

                if (DamageSources[i].GetComponent<TestingDamageSource>().Ability.AbilityIsActive() && res <= DamageSources[i].GetComponent<TestingDamageSource>().Ability.AbilityChance)
                {
                    Debug.Log(DamageSources[i].GetComponent<TestingDamageSource>().Name + " moves. Ability turn is at " + DamageSources[i].GetComponent<TestingDamageSource>().Ability.TurnsRemaining);
                    DamageSources[i].GetComponent<TestingDamageSource>().Ability.Use(DamageSources[i].GetComponent<TestingDamageSource>().Name);
                    enemyHP -= DamageSources[i].GetComponent<TestingDamageSource>().Ability.DamageDealt;
                }
                else if (!DamageSources[i].GetComponent<TestingDamageSource>().Ability.AbilityIsActive())
                {
                    Debug.Log(DamageSources[i].GetComponent<TestingDamageSource>().Name + "'s Ability is not active. " + DamageSources[i].GetComponent<TestingDamageSource>().Ability.TurnsRemaining + " left.");
                }
            }
            #endregion

            #region Enemy side.
            for (int i = 0; i < numberOfEnemies; i++)
            {
                yield return new WaitForSeconds(0.2f);

                bool disabled = false;
                
                foreach(int a in disabledNumber)
                {
                    disabled = i == a;

                    if (disabled) break;
                }

                if(!disabled)
                {
                    int res;

                    res = UnityEngine.Random.Range(0, 100);

                    if (res <= 30)
                    {
                        Debug.Log("Enemy " + i.ToString() + " hit the enemy.");
                        allyHP -= 50;
                    }
                    else
                        Debug.Log("Enemy " + i.ToString() + " missed.");

                    res = UnityEngine.Random.Range(0, 100);

                    if (res <= 20)
                    {
                        Debug.Log("Ability is used.");
                        allyHP -= 100;
                    }
                    else
                        Debug.Log("Enemy " + i.ToString() + " missed their ability.");
                }
                else
                {
                    Debug.Log("Enemy " + i + " disabled.");
                }
            }
            #endregion
        }

        string winner = enemyHP <= 0 ? "Enemy lost." : "Allies lost.";

        Debug.Log("Test end. " + winner);
        Debug.Log("Enemies: " + enemyHP + "\nAllies: " + allyHP);
    }
    #endregion

    // Update is called once per frame
    void Update ()
    {
        #region testing
        if(!battleHasStarted)
            timer -= Time.deltaTime * 1f;
        
        if(timer <= 0 && !battleHasStarted)
            StartCoroutine(TestBattleStart());
        #endregion
    }
}