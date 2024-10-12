using UnityEngine;
/// <summary>
/// Команда для апгрейду будівлі.
/// </summary>
public class UpgradeCommand : ICommand
{
    private BuildingContext _context;

    public UpgradeCommand(BuildingContext context)
    {
        _context = context;
    }

    public void Execute()
    {
        // Логіка для апгрейду будівлі
        if (_context.CurrentState is BuiltState)
        {
            Debug.Log("Upgrading the building.");
            // Додаємо логіку для зміни стану чи інших дій
        }
        else
        {
            Debug.Log("Building cannot be upgraded in the current state.");
        }
    }
}