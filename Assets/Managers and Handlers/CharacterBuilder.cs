using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;



public class CharacterBuilder : MonoBehaviour
{
    [SerializeField] GameObject _concreteCharacterObjectReference;

	// Use this for initialization
	void Start ()
    {
        string newName = GetNewName(BiologicalSex.Female);

        Debug.Log(newName);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            BuildConcreteCharacterObject();
        }
	}

    void BuildConcreteCharacterObject()
    {
        GameObject newCharacter = _concreteCharacterObjectReference;

        Instantiate( newCharacter, transform );
    }

    void BuildConcreteCharacterObject(string existingJsonFileName)
    {

    }

    void BuildConcreteCharacterObject(string[] existingJsonFileNameList)
    {

    }

    // Creates a new value inhabitant config object for use by a character.
    public InhabitantValueConfig CreateNewConfig()
    {
        InhabitantValueConfig newConfig = new InhabitantValueConfig();

        #region Assignment of new InhabitantValueConfig variables.
        newConfig.Sex = (byte)AssignSex();
        newConfig.Name = GetNewName((BiologicalSex)newConfig.Sex);

        newConfig.LoyaltyValue = AssignStartingLoyaltyValue();
        newConfig.HealthValue = AssignStartingHealthValue();
        newConfig.IDNumber = CreateNewIDNumber();

        newConfig.RoleExpertise = 1;
        newConfig.RoleValue = 0;
        #endregion

        return newConfig;
    }

    public InhabitantValueConfig MapToConfig(Inhabitant inhabitantValues)
    {
        InhabitantValueConfig mappedConfig = new InhabitantValueConfig();

        #region Properties mapped to the variables of the config file.
        mappedConfig.Name = inhabitantValues.Name;
        mappedConfig.Sex = (byte)inhabitantValues.Sex;

        mappedConfig.HealthValue = (byte)inhabitantValues.Status.Health;
        mappedConfig.LoyaltyValue = (byte)inhabitantValues.Status.Loyalty;
        mappedConfig.IDNumber = inhabitantValues.Status.IDNumber;

        mappedConfig.RoleExpertise = inhabitantValues.RoleInformation.Expertise;
        mappedConfig.RoleValue = (byte)inhabitantValues.RoleInformation.Job;
        #endregion

        return mappedConfig;
    }

    // Generates a new name based on the biological sex of the character.
    string GetNewName(BiologicalSex s)
    {
        // The array of names pre-allocated from the text file.
        string[] nameArray = File.ReadAllLines(Globals.ReturnDependencyPath(FileDependencyType.PlainText) + "AmericanNames.txt");

        #region The variables used for creating the name of an individual.
        /// The STARTING index of all names within the array.
        /// For female names, the index is 0 - 299 [1 - 300]. For male names, the index is 300 - 599 [301 - 600]. 
        /// A last name can be any of the 810 names on the list.
        int startIndex;

        /// The first and last names of the person.
        string firstName, lastName;
        #endregion

        #region Assignment of indices, randomization of names.
        if (s == BiologicalSex.Nonbinary)
            startIndex = Random.Range(1, 100) > 50 ? 301 - 1 : 0;
        else
            startIndex = s == BiologicalSex.Female ? 0 : 301 - 1;

        /// Assigning the random names.
        /// The first name is between a clearly defined starting and ending indice.
        /// A possible last name is everything in the array.
        firstName = nameArray[Random.Range(startIndex, startIndex + 300)];
        lastName = nameArray[Random.Range(0, nameArray.Length - 1)];

        // A loop ensuring that the first and last names are never the same.
        while (lastName == firstName && lastName != string.Empty)
            lastName = nameArray[Random.Range(0, nameArray.Length - 1)];
        #endregion

        return string.Format("{0} {1}", firstName, lastName);
    }

    // Returns a biological sex for the built character.
    BiologicalSex AssignSex()
    {
        int[] results = new int[3];
        int aboveHalfCounter = 0;
        bool isNonbinary = false;

        for (int i = 0; i < results.Length; i++)
        {
            isNonbinary = Random.Range(1, 100) < 10;

            if(!isNonbinary)
            {
                results[i] = Random.Range(1, 100);

                aboveHalfCounter = results[i] > 50 ? aboveHalfCounter + 1 : aboveHalfCounter;
            }
            else
                break;
        }

        if (isNonbinary)
            return BiologicalSex.Nonbinary;
        if (aboveHalfCounter > 1)
            return BiologicalSex.Male;

        return BiologicalSex.Female;
    }

    byte AssignStartingLoyaltyValue()
    {
        int res = Random.Range(1, 100);

        if (res >= 1 && res <= 33)
            return 1;
        else if (res >= 34 && res <= 66)
            return 2;

        return 3;
    }

    byte AssignStartingHealthValue()
    {
        return 3;
    }

    string CreateNewIDNumber()
    {
        string[] idNumArray = new string[6];

        for (byte i = 0; i < idNumArray.Length; i++)
            idNumArray[i] = Random.Range(0, 9).ToString();

        StringBuilder builtString = new StringBuilder();

        foreach(string s in idNumArray)
            builtString.Append(s);

        return builtString.ToString();
    }
}