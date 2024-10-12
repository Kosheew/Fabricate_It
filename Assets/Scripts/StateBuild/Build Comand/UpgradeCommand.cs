using UnityEngine;
/// <summary>
/// ������� ��� �������� �����.
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
        // ����� ��� �������� �����
        if (_context.CurrentState is BuiltState)
        {
            Debug.Log("Upgrading the building.");
            // ������ ����� ��� ���� ����� �� ����� ��
        }
        else
        {
            Debug.Log("Building cannot be upgraded in the current state.");
        }
    }
}