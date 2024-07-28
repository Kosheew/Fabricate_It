using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltState : IBuildingState
{
    public void Enter(BuildingContext context)
    {
        // ����� ��������� � ���� "����������"
        Debug.Log("Building is now Built.");
    }

    public void Exit(BuildingContext context)
    {
        // ����� ������ � ����� "����������"
    }

    public void Update(BuildingContext context)
    {
        // ����� ��������� � ���� "����������"
    }
}
