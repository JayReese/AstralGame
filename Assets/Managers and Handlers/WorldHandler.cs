using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHandler : MonoBehaviour
{
    [SerializeField] Transform _worldMapReference;

    [SerializeField] Transform sanc;

	// Use this for initialization
	void Start ()
    {
        _worldMapReference = GameObject.FindGameObjectWithTag("World").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Transform ReturnCorrectLocationInWorld(bool goToSanctuary)
    {
        if (goToSanctuary)
            return _worldMapReference.Find("Sanctuary");
        
        // Temporarily returning the map as a whole.
        return _worldMapReference;
    }
}
