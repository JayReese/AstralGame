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
    List<Unit> speedOrder;
    int targetDist, unitDist;

    // Use this for initialization
    void Start ()
    {
        string jsonstring = File.ReadAllText(Application.streamingAssetsPath + "/JSON/Units/RiflemanUnit.json");
        testUnit = JsonUtility.FromJson<CombatUnit>(jsonstring);
        string jsonstring2 = File.ReadAllText(Application.streamingAssetsPath + "/JSON/Enemies/TestEnemy.json");
        enemyA = JsonUtility.FromJson<Enemy>(jsonstring2);
        Debug.Log(testUnit.range);
        //Debug.Log(enemyA.hp);
        TestAccuracy();

        StartCoroutine(TestBattlePhase());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void TestAccuracy()
    {
        targetDist = 30;

        speedOrder = new List<Unit>();
        speedOrder.Add(enemyA);
        speedOrder.Add(testUnit);

        speedOrder = speedOrder.OrderBy( x => x.speed ).ToList();
        speedOrder.Reverse();
        Debug.Log( speedOrder[0].type );
    }

    IEnumerator TestBattlePhase()
    {
        enemyA.target = testUnit;
        testUnit.target = enemyA;

        int damageDealt;

        while (testUnit.hp > 0 && enemyA.hp > 0)
        {
            foreach(Unit u in speedOrder)
            {
                yield return new WaitForSeconds(0.5f);

                damageDealt = TestCalculatedDamage(u);
                
                u.target.hp = u.target.hp - damageDealt <= 0 ? 0 : u.target.hp - damageDealt;
                
                Debug.Log(string.Format("{0} attacked {1}. {2} damage dealt!\n{3} at {4} HP.", u.type, u.target, damageDealt, u.target.type, u.target.hp));

                if (testUnit.hp <= 0 || enemyA.hp <= 0)
                    break;
            }
        }

        if (testUnit.hp <= 0)
            Debug.Log("You lose.");
        else if (enemyA.hp <= 0)
            Debug.Log("You win.");
    }

    private int TestCalculatedDamage(Unit attacker)
    {
        if (targetDist > attacker.range)
            return attacker.strength / 2;

        return attacker.strength;
    }
}