using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderConstructionState : IBuildingState
{
    public void Enter(BuildingContext context)
    {
        // Логіка входження в стан "Будується"
        Debug.Log("Building is now Under Construction.");
    }

    public void Exit(BuildingContext context)
    {
        // Логіка виходу з стану "Будується"
    }

    public void Update(BuildingContext context)
    {
        // Логіка оновлення в стані "Будується"
    }
}
