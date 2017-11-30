using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHueChanger : MonoBehaviour
{
    HSBColor testColor;
	// Use this for initialization
	void Start ()
    {
        testColor = new HSBColor(Color.green);
	}
	
	// Update is called once per frame
	void Update ()
    {
        testColor.h = 0.8f;
        
        GetComponent<SpriteRenderer>().color = testColor.ToColor();
    }
}
