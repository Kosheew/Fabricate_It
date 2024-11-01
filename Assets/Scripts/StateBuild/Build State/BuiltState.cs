using UnityEngine;
using CommandBuild;
using CommandBuild.Build;
using Buildings;

namespace BuildingState
{
    public class BuiltState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
            context.MeshBuild.mesh = context.BuildSettings.MeshBuilding;

            context.BuildData.CurrentState = nameof(BuiltState);

            // ����� ��������� � ���� "����������"
            Debug.Log("Building is now Built.");
        }

        public void Exit(BuildingContext context)
        {
            // ����� ������ � ����� "����������"
        }

        public void ShowPanel(BuildingContext context)
        {
            context.StateBuildView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
            //// ����� ��������� � ���� "����������"
            //// ���� ��������� �������, �������� �������
            //if (context.NeedsUpgrade)
            //{
            //    _upgradeCommand.Execute();
            //}
        }
    }
}