using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderConstructionState : IBuildingState
{
    public void Enter(BuildingContext context)
    {
        // ����� ��������� � ���� "��������"
        Debug.Log("Building is now Under Construction.");
    }

    public void Exit(BuildingContext context)
    {
        // ����� ������ � ����� "��������"
    }

    public void Update(BuildingContext context)
    {
        // ����� ��������� � ���� "��������"
    }
}
