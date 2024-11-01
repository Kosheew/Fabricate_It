using UnityEngine;
using CommandBuild;
using CommandBuild.Build;
using Buildings;

namespace BuildingState
{
    public class BuiltState : IBuildingState
    {
        private CommandBuild.Command _upgradeCommand;

        public void Enter(BuildingContext context)
        {
            context.MeshBuild.mesh = context.BuildSettings.MeshBuilding;

            // ����� ��������� � ���� "����������"
            Debug.Log("Building is now Built.");

            // ����������� ������� ��������
            _upgradeCommand = new UpgradeCommand(context);
        }

        public void Exit(BuildingContext context)
        {
            // ����� ������ � ����� "����������"
        }

        public void ShowPanel(BuildingContext context)
        {
            //context.UpgradeOrViewBuildingView.ShowStatePanel();
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
}