using UnityEngine;
using Command;
using Command.Build;
using Buildings;

namespace BuildingState
{
    public class DestroyedState : IBuildingState
    {
        private ICommand _repairCommand;

        public void Enter(BuildingContext context)
        {
            // Логіка входження в стан "Зруйнована"
            Debug.Log("Building is now Destroyed.");

            _repairCommand = new RepairCommand(context);
        }

        public void Exit(BuildingContext context)
        {
            // Логіка виходу з стану "Зруйнована"
        }

        public void ShowPanel(BuildingContext context)
        {
            context.RestoreBuildingView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
            // Логіка оновлення в стані "Зруйнована"
            if (context.NeedsRepair)
            {
                _repairCommand.Execute();
            }
        }
    }
}
