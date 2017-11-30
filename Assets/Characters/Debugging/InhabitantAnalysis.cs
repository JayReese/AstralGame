using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhabitantAnalysis : MonoBehaviour
{
    Inhabitant _inhabitantReference;

    [SerializeField] string _name;
    [SerializeField] BiologicalSex _sex;

    [SerializeField] LoyaltyLevel _loyalty;
    [SerializeField] HealthLevel _health;
    [SerializeField] string _idNumber;

    [SerializeField] RoleType _job;
    [SerializeField] byte _roleExpertise;

	// Use this for initialization
	void Start ()
    {
        _inhabitantReference = GetComponent<Inhabitant>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetCurrentAnalysisVariables();
    }

    void SetCurrentAnalysisVariables()
    {
        _name = _inhabitantReference.Name;
        _sex = _inhabitantReference.Sex;

        _loyalty = _inhabitantReference.Status.Loyalty;
        _health = _inhabitantReference.Status.Health;
        _idNumber = _inhabitantReference.Status.IDNumber;

        _job = _inhabitantReference.RoleInformation.Job;
        _roleExpertise = _inhabitantReference.RoleInformation.Expertise;
    }
}
