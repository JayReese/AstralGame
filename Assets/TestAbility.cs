using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAbility
{
    public int TurnsNeededToActivate { get;  private set; }
    public int DamageDealt { get; private set; }
    public int AbilityChance { get; private set; }

    public int TurnsRemaining;
    int _baseAbilityChance;

    public TestAbility(int turnsNeeded, int damageDealt, int chanceToOccur)
    {
        TurnsNeededToActivate = turnsNeeded;
        DamageDealt = damageDealt;
        AbilityChance = chanceToOccur;

        _baseAbilityChance = AbilityChance;

        TurnsRemaining = TurnsNeededToActivate;
    }

    public void SubtractTurn(string name)
    {
        TurnsRemaining--;

        if (TurnsRemaining <= -1 && AbilityChance < 95)
        {
            AbilityChance += 10;
            Debug.Log(name + "'s turn is at " + TurnsRemaining + ". new ability chance from overdraft is " + AbilityChance);
        }
           
    }

    public bool AbilityIsActive()
    {
        return TurnsRemaining <= 0;
    }

    public void Use(string name)
    {
        if (AbilityIsActive())
        {
            Debug.Log(name + " ability was used. Damage dealt is " + DamageDealt + ".");
            TurnsRemaining = TurnsNeededToActivate;
            AbilityChance = _baseAbilityChance;
        }
        else
            Debug.Log("Ability isn't ready yet.");
    }


}
