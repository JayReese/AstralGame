using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDamageSource : MonoBehaviour
{
    public int DamageToDeal, SuccessChance, HP;
    public string Name;
    public TestAbility Ability;
    

	// Use this for initialization
	void Start ()
    {
        HP = Random.Range(400, 900);
        SuccessChance = Random.Range(40, 60);
        DamageToDeal = Random.Range(10, 12) * Random.Range(1, 3);
        Ability = new TestAbility(3, 300, 20);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetName(int nameID)
    {
        Name = string.Format("Johnson {0}", nameID.ToString());
    }

    public void ReturnSuccessChance()
    {
        Debug.Log(SuccessChance);
    }

    public void AdvanceTime()
    {
        Ability.SubtractTurn(Name);
    }
}
