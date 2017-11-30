using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    [SerializeField] ManagerNexus ManagingNexus;
    [SerializeField] int _charactersToBeHandledAmount;
    [SerializeField] private bool _newCharactersInExistence;

    // Might have its protection level changed in the future, who knows. Till then,
    // it stays private and exposed to the inspector.
    [SerializeField] List<GameObject> InhabitantCensus;
    

    // Use this for initialization
    void Start ()
    {
        ManagingNexus = transform.parent.GetComponent<ManagerNexus>();
        InhabitantCensus = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckForCharacterHandlingPopulation();	
	}

    void CheckForCharacterHandlingPopulation()
    {

        if (NewCharacterDetected())
        {
            for (byte i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<Inhabitant>().AssignInhabitantValues(ManagingNexus.CharacterBuilding.CreateNewConfig());

                Debug.Log("New character: " + transform.GetChild(i).gameObject.GetComponent<Inhabitant>().Name);

                if (!transform.GetChild(i).GetComponent<InhabitantAnalysis>())
                    transform.GetChild(i).gameObject.AddComponent<InhabitantAnalysis>();

                ManagingNexus.JsonHandling.MapToJson(ManagingNexus.CharacterBuilding.MapToConfig(transform.GetChild(i).gameObject.GetComponent<Inhabitant>()));

                SendCharacterToLocation(transform.GetChild(i).gameObject);
            }

            #region COMMENTED OUT - individual character handling.
            //GameObject detectedNewCharacter = transform.GetChild(transform.childCount - 1).gameObject;

            //detectedNewCharacter.GetComponent<Inhabitant>().AssignInhabitantValues(ManagingNexus.CharacterBuilding.CreateNewConfig());

            //if (!detectedNewCharacter.GetComponent<InhabitantAnalysis>()) detectedNewCharacter.gameObject.AddComponent<InhabitantAnalysis>();

            //SendCharacterToLocation(detectedNewCharacter);
            #endregion
        }
    }

    IEnumerator PerformNewCharacterOperations()
    {
        yield return new WaitForSeconds(0.2f);
    }

    void SendCharacterToLocation(GameObject characterToRelocate)
    {
        characterToRelocate.transform.parent = ManagingNexus.WorldHandling.ReturnCorrectLocationInWorld(true);
    }

    bool NewCharacterDetected()
    {
        return transform.childCount > 0;
    }
}
