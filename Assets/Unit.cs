﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit
{
    public string type;
    public int speed, hp, strength, range, accuracy, cost;
    public Unit target;
}
