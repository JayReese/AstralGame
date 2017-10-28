using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestUnitManager : MonoBehaviour
{

    string baseStreamingAssetsJsonPath;

	// Use this for initialization
	void Start ()
    {
        baseStreamingAssetsJsonPath = Application.streamingAssetsPath + "/JSON/";
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

        #region Variable mapping to new UnitStatConfig.
        newConfig.Name = unitToMap.name;

        newConfig.Expertise = unitToMap.expertise;

        newConfig.AttackRate = unitToMap.Tactics.Stats.AttackRate;
        newConfig.Strength = unitToMap.Tactics.Stats.Strength;
        #endregion

        return newConfig;
    }

    public void TestPasstoJSON(UnitStatConfig u)
    {
        string newJson = JsonUtility.ToJson(u);

        Debug.Log(newJson);

        // Writes to a json file in the specified folder.
        // This either creates a new file, or simply
        // overwrites the file with new information.
        File.WriteAllText(baseStreamingAssetsJsonPath + "/Testing/" + u.Name.Replace(" ", string.Empty) + ".json", newJson);
    }
}