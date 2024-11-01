using UnityEngine;
using Buildings;

namespace BuildingState
{
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

        public void ShowPanel(BuildingContext context)
        {
           // context.RestoreBuildingView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
           
        }
    }
}
