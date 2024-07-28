using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedState : IBuildingState
{
    public void Enter(BuildingContext context)
    {
        // ����� ��������� � ���� "����������"
        Debug.Log("Building is now Destroyed.");
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
