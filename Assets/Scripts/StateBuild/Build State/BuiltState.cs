using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltState : IBuildingState
{
    private ICommand _upgradeCommand;

    public void Enter(BuildingContext context)
    {
        // Логіка входження в стан "Побудована"
        Debug.Log("Building is now Built.");

        // Ініціалізація команди апгрейду
        _upgradeCommand = new UpgradeCommand(context);
    }

    public void Exit(BuildingContext context)
    {
        // Логіка виходу з стану "Побудована"
    }

    public void Update(BuildingContext context)
    {
        // Логіка оновлення в стані "Побудована"
        // Якщо викликано апгрейд, виконуємо команду
        if (context.NeedsUpgrade)
        {
            _upgradeCommand.Execute();
        }
    }
}

