using UnityEngine;
using Buildings;

namespace BuildingState
{
    public class DestroyedState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
            context.BuildData.CurrentState = nameof(DestroyedState);
            Debug.Log("Building is now Destroyed.");

        }

        public void Exit(BuildingContext context)
        {
            // Ћог≥ка виходу з стану "«руйнована"
        }

        public void ShowPanel(BuildingContext context)
        {
            context.RepairBuildView.ShowStatePanel();
        }

        public void Update(BuildingContext context)
        {
           
        }
    }
}
