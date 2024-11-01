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

            // Логіка входження в стан "Побудована"
            Debug.Log("Building is now Built.");

            // Ініціалізація команди апгрейду
            _upgradeCommand = new UpgradeCommand(context);
        }

        public void Exit(BuildingContext context)
        {
            // Логіка виходу з стану "Побудована"
        }

        public void ShowPanel(BuildingContext context)
        {
            //context.UpgradeOrViewBuildingView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
            // Логіка оновлення в стані "Побудована"
            // Якщо викликано апгрейд, виконуємо команду
            if (context.NeedsUpgrade)
            {
                _upgradeCommand.Execute();
            }
        }
    }
}