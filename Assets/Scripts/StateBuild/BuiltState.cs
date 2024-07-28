using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltState : IBuildingState
{
    public void Enter(BuildingContext context)
    {
        // Логіка входження в стан "Побудована"
        Debug.Log("Building is now Built.");
    }

    public void Exit(BuildingContext context)
    {
        // Логіка виходу з стану "Побудована"
    }

    public void Update(BuildingContext context)
    {
        // Логіка оновлення в стані "Побудована"
    }
}
