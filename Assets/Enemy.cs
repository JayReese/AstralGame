using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    string _description;

    public string Description
    {
        get { return _description; }
    }

    public Enemy()
    {
        _description = EnemyDescription();
        Allegiance = Allegiances.Enemy;
    }

    protected virtual string EnemyDescription()
    {
        return "A test enemy";
    }
}