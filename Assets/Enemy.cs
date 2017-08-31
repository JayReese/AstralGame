using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public string description;

    public Enemy()
    {
        Allegiance = Allegiances.Enemy;
    }
}
