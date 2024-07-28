using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedState : IBuildingState
{
    public void Enter(BuildingContext context)
    {
        // Логіка входження в стан "Зруйнована"
        Debug.Log("Building is now Destroyed.");
    }

    public void Exit(BuildingContext context)
    {
        // Логіка виходу з стану "Зруйнована"
    }

    public void Update(BuildingContext context)
    {
        // Логіка оновлення в стані "Зруйнована"
    }
}
