using UnityEngine;
/// <summary>
/// Команда для ремонту зруйнованої будівлі.
/// </summary>
public class RepairCommand : ICommand
{
    private BuildingContext _context;

    public RepairCommand(BuildingContext context)
    {
        _context = context;
    }

    public void Execute()
    {
        // Логіка для ремонту будівлі
        if (_context.CurrentState is DestroyedState)
        {
            Debug.Log("Repairing the building.");
            _context.TransitionToState(_context.UnderConstructionState);
        }
        else
        {
            Debug.Log("Building cannot be repaired in the current state.");
        }
    }
}