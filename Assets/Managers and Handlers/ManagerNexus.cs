using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerNexus : MonoBehaviour
{
    public CharacterBuilder CharacterBuilding;
    public CharacterHandler CharacterHandling;

    public WorldBuilder WorldBuilding;
    public WorldHandler WorldHandling;

    public JsonHandler JsonHandling;

    //public delegate void ManagerAction();
    //public ManagerAction ExecuteManagerLog;

    private void Awake()
    {
        SetManagerHandlingDefaults();
    }

    // Could possibly be changed to SetDefaults() with an override if there are multiple types of
    // manager handlers running around.
    void SetManagerHandlingDefaults()
    {
        CharacterBuilding = transform.Find("Character Handling").GetComponent<CharacterBuilder>();
        CharacterHandling = transform.Find("Character Handling").GetComponent<CharacterHandler>();

        WorldBuilding = transform.Find("World Handling").GetComponent<WorldBuilder>();
        WorldHandling = transform.Find("World Handling").GetComponent<WorldHandler>();

        JsonHandling = transform.Find("File & Database Handling").GetComponent<JsonHandler>();
    }
}
