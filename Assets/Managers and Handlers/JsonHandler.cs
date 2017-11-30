using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{
    string _baseStreamingAssetsJsonPath;
    // Use this for initialization
    void Start ()
    {
        _baseStreamingAssetsJsonPath = Application.streamingAssetsPath + "/JSON/";
        Debug.Log(Globals.ReturnDependencyPath(FileDependencyType.JSON));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MapToJson(InhabitantValueConfig configFile)
    {
        string newJson = GenerateJsonStringFromConfig(configFile);
        Debug.Log(newJson);

        //File.WriteAllText(_baseStreamingAssetsJsonPath + "/Testing/" + configFile.Name.Replace(" ", string.Empty) + ".json", newJson);
        File.WriteAllText(Globals.ReturnDependencyPath(FileDependencyType.JSON) + "/Testing/" + configFile.IDNumber + ".json", newJson);
    }

    string GenerateJsonStringFromConfig(InhabitantValueConfig c)
    {
        return JsonUtility.ToJson(c);
    }
}
