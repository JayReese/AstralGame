using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhabitantStatus
{
    public LoyaltyLevel Loyalty;
    public HealthLevel Health;

    public string IDNumber;

    public InhabitantStatus(InhabitantValueConfig config)
    {
        Loyalty = (LoyaltyLevel)config.LoyaltyValue;
        Health = (HealthLevel)config.HealthValue;

        IDNumber = config.IDNumber;
    }
}