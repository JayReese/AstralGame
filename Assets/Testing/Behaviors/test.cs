using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public object Create(string pattern)
    {
        Type t = Type.GetType(pattern);

        //if (t == null)
        //    throw new Exception("Type " + pattern + " not found.");

        //Debug.Log(t);

        return Activator.CreateInstance(t);
        //Debug.Log(newthing.GetType());
    }

    //public Unit CreateUnit(string unitType)
    //{
    //    Type t = Type.GetType(unitType);

    //    if (t == null)
    //        throw new Exception("Type " + unitType + " not found.");

    //    //return Activator.CreateInstance(t);
    //}
}
