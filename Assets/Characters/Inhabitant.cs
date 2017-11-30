using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inhabitant : Entity
{
    public string Name { get; private set; }
    public BiologicalSex Sex { get; private set; }

    [SerializeField] bool _statTrackingActive;
    [SerializeField] public InhabitantValueConfig _config;

    public InhabitantStatus Status { get; private set; }
    //List<InhabitantRole> Roles;
    public InhabitantRole RoleInformation { get; private set; }

    private void Awake()
    {
        //Roles = new List<InhabitantRole>();
        _statTrackingActive = false;
    }

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(MakeStatsTrackable());
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetConcreteNameOfInhabitant();
	}

    IEnumerator MakeStatsTrackable()
    {
        yield return new WaitForSeconds(1f);
        _statTrackingActive = true;
    }

    public void AssignInhabitantValues()
    {
        Status = new InhabitantStatus(_config);
    }

    public void AssignInhabitantValues(InhabitantValueConfig config)
    {
        Name = config.Name;
        Sex = (BiologicalSex)config.Sex;

        Status = new InhabitantStatus(config);
        RoleInformation = new InhabitantRole(config);
    }

    void SetConcreteNameOfInhabitant()
    {
        if (Status != null && gameObject.name != Name && Name != null)
            gameObject.name = Name;
    }
}
