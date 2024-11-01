using UnityEngine;
using Buildings;

namespace BuildingState
{
    public class DestroyedState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
            // Логіка входження в стан "Зруйнована"
            Debug.Log("Building is now Destroyed.");

        }

        public void Exit(BuildingContext context)
        {
            // Логіка виходу з стану "Зруйнована"
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
