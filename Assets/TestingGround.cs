using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class TestingGround : MonoBehaviour
{
    CombatUnit testUnit;
    Enemy enemyA;

    // Use this for initialization
    void Start ()
    {
        string jsonstring = File.ReadAllText(Application.streamingAssetsPath + "/JSON/Units/RiflemanUnit.json");
        testUnit = JsonUtility.FromJson<CombatUnit>(jsonstring);
        string jsonstring2 = File.ReadAllText(Application.streamingAssetsPath + "/JSON/Enemies/TestEnemy.json");
        enemyA = JsonUtility.FromJson<Enemy>(jsonstring2);
        Debug.Log(testUnit.cost);
        Debug.Log(enemyA.description);
        TestAccuracy();


	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void TestAccuracy()
    {
        int targetDist = 10;
        int unitDist = 10;

        List<Unit> speedOrder = new List<Unit>();
        speedOrder.Add(enemyA);
        speedOrder.Add(testUnit);

        speedOrder = speedOrder.OrderBy( x => x.speed ).ToList();
        speedOrder.Reverse();
        Debug.Log( speedOrder[0].type );
    }
}
