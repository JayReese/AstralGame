using System.Collections;
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
       // UnitStatConfig config = 

        return JsonUtility.FromJson<UnitStatConfig>(File.ReadAllText(Application.streamingAssetsPath + "/JSON/" + s));
    }
}
