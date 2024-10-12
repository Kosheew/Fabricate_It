using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedState : IBuildingState
{
    private ICommand _repairCommand;

    public void Enter(BuildingContext context)
    {
        // ����� ��������� � ���� "����������"
        Debug.Log("Building is now Destroyed.");

        // ����������� ������� ��� ����������
        _repairCommand = new RepairCommand(context);
    }

    public void Exit(BuildingContext context)
    {
        // ����� ������ � ����� "����������"
    }

    public void Update(BuildingContext context)
    {
        // ����� ��������� � ���� "����������"
        if (context.NeedsRepair)
        {
            _repairCommand.Execute();
        }
    }
}
