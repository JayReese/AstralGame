using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class TestingGround : MonoBehaviour
{
    CombatUnit testUnit;
    Enemy enemyA;
    List<Unit> speedOrder, allyUnits, enemyUnits;
    int targetDist, unitDist;

    // Use this for initialization
    void Start ()
    {
        string jsonstring = File.ReadAllText(Application.streamingAssetsPath + "/JSON/Units/RiflemanUnit.json");
        testUnit = JsonUtility.FromJson<CombatUnit>(jsonstring);
        string jsonstring2 = File.ReadAllText(Application.streamingAssetsPath + "/JSON/Enemies/TestEnemy.json");
        enemyA = JsonUtility.FromJson<Enemy>(jsonstring2);
        //Debug.Log(testUnit.range);
        //Debug.Log(enemyA.hp);
        TestCreateBattlefieldPieces();

        TestMakeSpeedOrders();

       // StartCoroutine(TestBattlePhase());
	}

    private void TestCreateBattlefieldPieces()
    {
        int count = 5;
        allyUnits = new List<Unit>();
        enemyUnits = new List<Unit>();

        for(int i = 0; i < count; i++)
        {
            AllyUnit a = JsonUtility.FromJson<AllyUnit>(File.ReadAllText(Application.streamingAssetsPath + "/JSON/Units/RiflemanUnit.json"));

            allyUnits.Add(a);
            Debug.Log(allyUnits[i].distanceFromCenter);
            allyUnits[i].Allegiance = Unit.Allegiances.Ally;
            allyUnits[i].ChangeName(i);

            Enemy b = JsonUtility.FromJson<Enemy>(File.ReadAllText(Application.streamingAssetsPath + "/JSON/Enemies/TestEnemy.json"));

            enemyUnits.Add(b);
            allyUnits[i].Allegiance = Unit.Allegiances.Ally;
            enemyUnits[i].ChangeName(i);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    void TestMakeSpeedOrders()
    {
        targetDist = 30;

        speedOrder = new List<Unit>();

        speedOrder.AddRange(allyUnits);
        speedOrder.AddRange(enemyUnits);

        speedOrder = speedOrder.OrderBy( x => x.CombatStats.BaseSpeed ).ToList();
        speedOrder.Reverse();
        //Debug.Log( speedOrder[0].type );

        //speedOrder.ForEach(x => Debug.Log(x.name));
    }

    IEnumerator TestBattlePhase()
    {
        int damageDealt;

        while (allyUnits.Count > 0 && enemyUnits.Count > 0)
        {
            foreach (Unit u in speedOrder)
            {
                var targetList = u.Allegiance == Unit.Allegiances.Enemy ? allyUnits : enemyUnits;

                u.target = targetList[UnityEngine.Random.Range(0, targetList.Count)];
                Debug.Log(u.name + " has targeted " + u.target.name + ".");

                yield return new WaitForSeconds(0.5f);

                damageDealt = TestCalculatedDamage(u);

                if (AttackHit(u))
                {
                    u.target.hp = u.target.hp - damageDealt <= 0 ? 0 : u.target.hp - damageDealt;

                    Debug.Log(string.Format("{0} attacked {1}. {2} damage dealt!\n{3} at {4} HP.", u.name, u.target.name, damageDealt, u.target.name, u.target.hp));
                }
                else
                    Debug.Log(u.name + "'s attack missed.");
                

                if (u.target.hp <= 0)
                {
                    Debug.Log(u.target.name + " has been killed! " + targetList.Count + " left.");
                    TestRemoveFromPlay(targetList, u.target);
                }

                if (targetList.Count == 0)
                    break;
            }
        }

        if (allyUnits.Count == 0)
            Debug.Log("You lose.");
        else if (enemyUnits.Count == 0)
            Debug.Log("You win.");
    }

    private int TestCalculatedDamage(Unit attacker)
    {
        if (targetDist > attacker.range)
            return attacker.strength / 2;

        return attacker.strength;
    }

    private void TestRemoveFromPlay(List<Unit> targets, Unit targetToFind)
    {
        for(int i = 0; i < targets.Count; i++)
        {
            if (targetToFind.name == targets[i].name)
                targets.RemoveAt(i);
        }
    }   

    private bool AttackHit(Unit attacker)
    {
        int res = UnityEngine.Random.Range(1, 100);

        return res <= attacker.accuracy;
    }
}