using UnityEngine;
using Buildings;

namespace BuildingState
{
    public class DestroyedState : IBuildingState
    {
        public void Enter(BuildingContext context)
        {
            context.BuildData.CurrentState = nameof(DestroyedState);

            context.MeshBuild.mesh = context.BuildSettings.MeshDestroyed;

        }

        public void Exit(BuildingContext context)
        {
           
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
