using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Globals
{
    public static string ReturnDependencyPath(FileDependencyType dependencyTypeToFind)
    {
        return string.Format("{0}", Application.streamingAssetsPath + "/" + dependencyTypeToFind.ToString() + "/");
    }
}

public enum FileDependencyType { JSON, PlainText }

#region Inhabitant enums.
public enum LoyaltyLevel { Mutinous = 0, Distrustful, Amiable, Devoted }
public enum HealthLevel { Terminal = 0, Unhealthy, Adequate, Healthy }
public enum BiologicalSex { Female = 1, Male, Nonbinary }

public enum RoleType
{
    Unassigned,
    Technician,
    Builder,
    Hunter,
    Combatant,
    Medic
}
#endregion