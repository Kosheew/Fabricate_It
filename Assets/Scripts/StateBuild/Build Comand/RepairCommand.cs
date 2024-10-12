using UnityEngine;
/// <summary>
/// ������� ��� ������� ���������� �����.
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
        // ����� ��� ������� �����
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