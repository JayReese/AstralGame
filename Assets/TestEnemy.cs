using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public TestEnemy()
    {
        Tactics = new BattleTactics("/JSON/Enemies/TestEnemy.json");
    }

    protected override string EnemyDescription()
    {
        return "A better test enemy.";
    }

    protected override string SetUnitType()
    {
        return "Test Enemy";
    }
}
