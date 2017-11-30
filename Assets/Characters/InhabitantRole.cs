using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InhabitantRole
{
    public RoleType Job { get; private set; }
    public byte Expertise { get; private set; }

    public InhabitantRole(InhabitantValueConfig config)
    {
        Job = (RoleType)config.RoleValue;
        Expertise = config.RoleExpertise;
    }
}
