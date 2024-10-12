using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltState : IBuildingState
{
    private ICommand _upgradeCommand;

    public void Enter(BuildingContext context)
    {
        // ����� ��������� � ���� "����������"
        Debug.Log("Building is now Built.");

        // ����������� ������� ��������
        _upgradeCommand = new UpgradeCommand(context);
    }

    public void Exit(BuildingContext context)
    {
        // ����� ������ � ����� "����������"
    }

    public void Update(BuildingContext context)
    {
        // ����� ��������� � ���� "����������"
        // ���� ��������� �������, �������� �������
        if (context.NeedsUpgrade)
        {
            _upgradeCommand.Execute();
        }
    }
}

